// VARIABLE & FUNCTION DECLARATIONS -- DO NOT ALTER!!
var PowerCardScript = PowerCardScript || {};
var getBrightness = getBrightness || {};
var hexDec = hexDec || {};


// USER CONFIGUATION
var POWERCARD_ROUNDED_CORNERS = true;
var POWERCARD_ROUNDED_INLINE_ROLLS = true;
var POWERCARD_BORDER_SIZE = 1;
var POWERCARD_BORDER_COLOR = "#000";
var POWERCARD_USE_PLAYER_COLOR = false;


on("chat:message", function (msg) {
    // Exit if not an api command
    if (msg.type != "api") return;


    // Get the API Chat Command
    msg.who = msg.who.replace(" (GM)", "");
    msg.content = msg.content.replace("(GM) ", "");
    var command = msg.content.split(" ", 1);


    if (command == "!power") {
        // DEFINE VARIABLES
        var n = msg.content.split(" --");
        var PowerCard = {};
        var DisplayCard = "";
        var NumberOfAttacks = 1;
        var NumberOfDmgRolls = 1;
        var NumberOfRolls = 1;
        var Tag = "";
        var Content = "";

        // CREATE POWERCARD OBJECT ARRAY
        var a = 1;
        while (n[a]) {
            Tag = n[a].substring(0, n[a].indexOf("|"));
            Content = n[a].substring(n[a].indexOf("|") + 1);
            if (Tag.substring(0, 6).toLowerCase() == "attack") {
                NumberOfAttacks = Tag.substring(6);
                if (NumberOfAttacks === 0 || !NumberOfAttacks) NumberOfAttacks = 1;
                Tag = "attack";
            }
            if (Tag.substring(0, 6).toLowerCase() == "damage") {
                NumberOfDmgRolls = Tag.substring(6);
                if (NumberOfDmgRolls === 0 || !NumberOfDmgRolls) NumberOfDmgRolls = 1;
                Tag = "damage";
            }
            if (Tag.substring(0, 9).toLowerCase() == "multiroll") {
                NumberOfRolls = Tag.substring(9);
                if (NumberOfRolls === 0 || !NumberOfRolls) NumberOfRolls = 1;
                Tag = "multiroll";
            }
            PowerCard[Tag] = Content;
            a++;
        }

        // ERROR CATCH FOR EMPTY EMOTE
        if (PowerCard.emote == "") PowerCard.emote = '" "';

        // CREATE TITLE STYLE
        var TitleStyle = " font-family: Georgia; font-size: large; font-weight: normal; text-align: center; vertical-align: middle; padding: 5px 0px; margin-top: 0.2em; border: " + POWERCARD_BORDER_SIZE + "px solid " + POWERCARD_BORDER_COLOR + ";";

        // ROUNDED CORNERS ON TOP OF POWER CARD
        TitleStyle += (POWERCARD_ROUNDED_CORNERS) ? " border-radius: 10px 10px 0px 0px;" : "";

        // LIST OF PRE-SET TITLE TEXT & BACKGROUND COLORS FOR D&D 4E
        var AtWill = " color: #FFF; background-color: #040;";
        var Encounter = " color: #FFF; background-color: #400;";
        var Daily = " color: #FFF; background-color: #444;";
        var Item = " color: #FFF; background-color: #e58900;";
        var Recharge = " color: #FFF; background-color: #004;";

        // CHECK FOR PRESET TITLE COLORS
        if (!POWERCARD_USE_PLAYER_COLOR) {
            if (PowerCard.usage !== undefined && PowerCard.txcolor === undefined && PowerCard.bgcolor === undefined) {
                // PRESET TITLE COLORS
                TitleStyle += AtWill;
                if (PowerCard.usage.toLowerCase().indexOf("encounter") != -1) TitleStyle += Encounter;
                if (PowerCard.usage.toLowerCase().indexOf("daily") != -1) TitleStyle += Daily;
                if (PowerCard.usage.toLowerCase().indexOf("item") != -1) TitleStyle += Item;
                if (PowerCard.usage.toLowerCase().indexOf("recharge") != -1) TitleStyle += Recharge;
            } else {
                // CUSTOM TITLECARD TEXT & BACKGROUND COLORS
                TitleStyle += (PowerCard.txcolor !== undefined) ? " color: " + PowerCard.txcolor + ";" : " color: #FFF;";
                TitleStyle += (PowerCard.bgcolor !== undefined) ? " background-color: " + PowerCard.bgcolor + ";" : " background-color: #040;";
            }
        } else {
            // SET TITLE BGCOLOR TO PLAYER COLOR --- OVERRIDES ALL OTHER COLOR OPTIONS ---
            var PlayerBGColor = getObj("player", msg.playerid).get("color");
            var PlayerTXColor = (getBrightness(PlayerBGColor) < 50) ? "#FFF" : "#000";
            TitleStyle += " color: " + PlayerTXColor + "; background-color: " + PlayerBGColor + ";";
        }

        // DEFINE .leftsub and .rightsub
        if (PowerCard.leftsub === undefined) PowerCard.leftsub = (PowerCard.usage !== undefined) ? PowerCard.usage : "";
        if (PowerCard.rightsub === undefined) PowerCard.rightsub = (PowerCard.action !== undefined) ? PowerCard.action : "";
        var PowerCardDiamond = (PowerCard.leftsub == "" || PowerCard.rightsub == "") ? "" : " ♦ ";

        // BEGIN DISPLAYCARD CREATION
        DisplayCard += "<div style='" + TitleStyle + "' title='" + PowerCard.title + "'>" + PowerCard.name;
        DisplayCard += (PowerCard.leftsub !== "" || PowerCard.rightsub !== "") ? "<br><span style='font-family: Tahoma; font-size: small; font-weight: normal;'>" + PowerCard.leftsub + PowerCardDiamond + PowerCard.rightsub + "</span></div>" : "</div>";

        // ROW STYLE VARIABLES
        var OddRow = " background-color: #CEC7B6; color: #000;";
        var EvenRow = " background-color: #B6AB91; color: #000;";
        var RowStyle = " padding: 5px; border-left: " + POWERCARD_BORDER_SIZE + "px solid " + POWERCARD_BORDER_COLOR + "; border-right: " + POWERCARD_BORDER_SIZE + "px solid " + POWERCARD_BORDER_COLOR + "; border-radius: 0px;";
        var RowBackground = OddRow;
        var RowNumber = 1;
        var Indent = 0;
        var KeyCount = 0;

        // KEY LOOP
        var Keys = Object.keys(PowerCard);
        var ReservedTags = "attack, damage, multiroll, lb";
        var IgnoredTags = "format, emote, name, usage, action, defense, txcolor, bgcolor, leftsub, rightsub, ddn, desc, crit, title";
        while (KeyCount < Keys.length) {
            Tag = Keys[KeyCount];
            Content = PowerCard[Keys[KeyCount]];
            if (Tag.charAt(0) === "^") {
                Indent = (parseInt(Tag.charAt(1)) > 0) ? Tag.charAt(1) : 1;
                Tag = (parseInt(Tag.charAt(1)) > 0) ? Tag.substring(2) : Tag.substring(1);
                RowStyle += " padding-left: " + (Indent * 1.5) + "em;";
            }

            // CHECK FOR RESERVED & IGNORED TAGS
            if (ReservedTags.indexOf(Tag) != -1) {
                // ATTACK ROLLS
                if (Tag.toLowerCase() == "attack") {
                    for (var AttackCount = 0; AttackCount < NumberOfAttacks; AttackCount++) {
                        RowBackground = (RowNumber % 2 == 1) ? OddRow : EvenRow;
                        RowNumber += 1;
                        switch (PowerCard.format) {
                            case "dnd4e": {
                                if (AttackCount == 0) PowerCard.attack = PowerCard.attack.replace("]]", "]] vs " + PowerCard.defense + " ");
                                DisplayCard += "<div style='" + RowStyle + RowBackground + "'>" + PowerCard.attack + "</div>";
                                break;
                            }
                            case "ddn": {
                                DisplayCard += "<div style='" + RowStyle + RowBackground + "'>[ " + PowerCard.attack + " ] vs Armor Class</div>";
                                break;
                            }
                            default:
                                DisplayCard += "<div style='" + RowStyle + RowBackground + "'>" + PowerCard.attack + "</div>";
                        }
                    }
                }

                // DAMAGE ROLLS
                if (Tag.toLowerCase() == "damage") {
                    for (var DamageCount = 0; DamageCount < NumberOfDmgRolls; DamageCount++) {
                        RowBackground = (RowNumber % 2 == 1) ? OddRow : EvenRow;
                        RowNumber += 1;
                        DisplayCard += "<div style='" + RowStyle + RowBackground + "'>" + PowerCard.damage + "</div>";
                    }
                }

                // MULTIROLLS
                if (Tag.toLowerCase() == "multiroll") {
                    for (var MultiRoll = 0; MultiRoll < NumberOfRolls; MultiRoll++) {
                        RowBackground = (RowNumber % 2 == 1) ? OddRow : EvenRow;
                        RowNumber += 1;
                        DisplayCard += "<div style='" + RowStyle + RowBackground + "'>" + PowerCard.multiroll + "</div>";
                    }
                }

                // LINE BREAK
                if (Tag.toLowerCase() == "lb") {
                    DisplayCard += "<div style='" + RowStyle + RowBackground + "'> </div>";
                    DisplayCard += "<div style='" + RowStyle + RowBackground + "'>" + PowerCard.lb + "</div>";
                }
            } else if (IgnoredTags.indexOf(Tag.toLowerCase()) != -1) {
                // Do nothing
            } else {
                RowBackground = (RowNumber % 2 == 1) ? OddRow : EvenRow;
                RowNumber += 1;
                DisplayCard += "<div style='" + RowStyle + RowBackground + "'><b>" + Tag + ":</b> " + Content + "</div>";
            }
            KeyCount++;
        }

        // ADD ROUNDED CORNERS & BORDER TO BOTTOM OF POWER CARD
        if (POWERCARD_ROUNDED_CORNERS && KeyCount == (Keys.length)) DisplayCard = DisplayCard.replace(/border-radius: 0px;(?!.*border-radius: 0px;)/g, "border-radius: 0px 0px 10px 10px; border-bottom: " + POWERCARD_BORDER_SIZE + "px solid " + POWERCARD_BORDER_COLOR + ";");
        if (!POWERCARD_ROUNDED_CORNERS && POWERCARD_BORDER_SIZE) DisplayCard = DisplayCard.replace(/border-radius: 0px;(?!.*border-radius: 0px;)/g, "border-bottom: " + POWERCARD_BORDER_SIZE + "px solid " + POWERCARD_BORDER_COLOR + ";");

        // INLINE ROLLS REPLACEMENT
        var Count = 0;
        if (msg.inlinerolls !== undefined) {
            while (Count < msg.inlinerolls.length) {
                // REPLACE INLINE ROLL PLACEHOLDERS IN DisplayCard
                var numCopies = DisplayCard.split("$[[" + Count + "]]").length - 1;
                for (var i = 0; i < numCopies; i++) {
                    sendChat("", Count + " [[" + msg.inlinerolls[Count].expression + " ]]", function (m) {
                        var idx = parseInt(m[0].content.split(" ")[0]);
                        var rolldata = m[0].inlinerolls[1];
                        var inlineroll = PowerCardScript.buildInline(
                            rolldata.expression,
                            rolldata.results.rolls,
                            PowerCard.crit
                        );
                        DisplayCard = DisplayCard.replace("$[[" + idx + "]]", inlineroll);
                        if (DisplayCard.search(/\$\[\[\d+\]\]/g) == -1) {
                            // SEND OUTPUT TO CHAT
                            if (PowerCard.emote !== undefined) sendChat(msg.who, "/emas " + PowerCard.emote);
                            if (PowerCard.desc !== undefined) sendChat("", "/desc ");
                            sendChat("", "/direct " + DisplayCard);
                        }
                    });
                }
                Count += 1;
            }
        } else {
            // NO INLINE ROLLS
            if (PowerCard.emote !== undefined) sendChat(msg.who, "/emas " + PowerCard.emote);
            if (PowerCard.desc !== undefined) sendChat("", "/desc ");
            sendChat("", "/direct " + DisplayCard);
        }
    }
});


PowerCardScript.buildInline = function (expression, rolls, crit) {
    var InlineBorderRadius = (POWERCARD_ROUNDED_INLINE_ROLLS) ? 5 : 0;
    var rollOut = '<span style="text-align: center; vertical-align: text-middle; display: inline-block; min-width: 1.75em; border-radius: ' + InlineBorderRadius + 'px; padding: 2px 0px 0px 0px;" title="Rolling ' + expression + ' = ';
    var failRoll = critRoll = false;
    var modTotal = 0;
    var math;

    for (var k in rolls) {
        var low = (String(rolls[rolls.length - 1].text).trim().toLowerCase().indexOf("lr") != -1) ? parseInt(String(rolls[rolls.length - 1].text).trim().substring(2)) : 1;
        if (rolls.hasOwnProperty(k)) {
            var r = rolls[k];

            // ROLL.TYPE Grouping
            if (r.type == 'G') {
                for (var i in r.rolls) {
                    rollOut += '{';
                    for (var j in r.rolls[i]) {
                        var obj = PowerCardScript.parseRollData(r.rolls[i][j], crit, low, failRoll, critRoll);
                        rollOut += obj.rollOut;
                        modTotal += obj.modTotal;
                        failRoll = obj.failRoll || failRoll;
                        critRoll = obj.critRoll || critRoll;
                    }
                    rollOut += '}';
                }
            } else {
                var obj = PowerCardScript.parseRollData(r, crit, low, failRoll, critRoll);

                rollOut += obj.rollOut;
                modTotal += obj.modTotal;
                failRoll = obj.failRoll || failRoll;
                critRoll = obj.critRoll || critRoll;
            }
        }
    }
    rollOut += '" class="a inlinerollresult showtip tipsy-n';
    rollOut += (critRoll && failRoll ? ' importantroll' : (critRoll ? ' fullcrit' : (failRoll ? ' fullfail' : ''))) + '">' + modTotal + '</span>';
    return rollOut;
};


PowerCardScript.parseRollData = function (roll, crit, low, failRoll, critRoll) {
    var rollOut = '';
    var modTotal = 0;
    var math;
    var max = (crit !== undefined && roll.sides == 20) ? crit : roll.sides;

    // ROLL.TYPE Roll
    if (roll.type == 'R') {
        rollOut += '(';
        for (var m = 0; m < roll.results.length; m++) {
            var value = roll.results[m].v;
            var drop = roll.results[m].d;
            if (!drop) {
                switch (math) {
                    default:
                    case '+':
                        modTotal += value;
                        math = '';
                        break;
                    case '-':
                        modTotal -= value;
                        math = '';
                        break;
                    case '*':
                        modTotal *= value;
                        math = '';
                        break;
                    case '/':
                        modTotal /= value;
                        math = '';
                        break;
                }
            }
            critRoll = critRoll || (value >= max);
            failRoll = failRoll || (value <= low);
            rollOut += '<span class=\'basicdiceroll' + (value >= max ? ' critsuccess' : (value <= low ? ' critfail' : '')) + '\'>';
            rollOut += value + '</span>+';
        }
        rollOut = rollOut.substring(0, rollOut.length - 1) + ')';
    }

    // ROLL.TYPE Math
    var operator, operand;
    if (roll.type == 'M') {
        rollOut += roll.expr;
        if (roll.expr.length == 1) {
            math = roll.expr;
        } else {
            operator = ('' + roll.expr).substring(0, 1);
            operand = ('' + roll.expr).substring(operator.search(/[\d(]/) === 0 ? 0 : 1);
        }

        if (operand) {
            if (operand.search(/([\d+\-*/() d]|floor\(|ceil\()+\)?/g) === 0) {
                operand = operand.split('floor').join('Math.floor');
                operand = operand.split('ceil').join('Math.ceil');
                operand = eval((operator == '-' ? '-' : '') + operand);
            } else {
                operand = parseInt(operand);
            }

            switch (operator) {
                default:
                case '+':
                case '-':
                    modTotal += operand;
                    break;
                case '*':
                    modTotal *= operand;
                    break;
                case '/':
                    modTotal /= operand;
                    break;
            }
        }
    }

    return {
        rollOut: rollOut,
        modTotal: modTotal,
        critRoll: critRoll,
        failRoll: failRoll
    };
};


function getBrightness(hex) {
    hex = hex.replace('#', '');
    var c_r = hexDec(hex.substr(0, 2));
    var c_g = hexDec(hex.substr(2, 2));
    var c_b = hexDec(hex.substr(4, 2));
    return ((c_r * 299) + (c_g * 587) + (c_b * 114)) / 1000;
}


function hexDec(hex_string) {
    hex_string = (hex_string + '').replace(/[^a-f0-9]/gi, '');
    return parseInt(hex_string, 16);
}
