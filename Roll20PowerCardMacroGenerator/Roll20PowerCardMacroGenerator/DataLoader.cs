using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Roll20PowerCardMacroGenerator
{
    public class DataLoader
    {
        public List<string> LoadData(string filePath)
        {
            List<string> items = new List<string>();
            items = File.ReadAllLines(filePath).ToList();
            return items;
        }

        public List<Power> LoadDDIPowers(string filePath)
        {
            List<Power> powersList = new List<Power>();
            if (File.Exists(filePath))
            {
                try
                {
                    XDocument xdoc = XDocument.Load(filePath);
                    var powersData = from powerData in xdoc.Descendants("thing")
                                     select new
                                     {
                                         Name = powerData.Attribute("name").Value,
                                         Description = (powerData.Attribute("description") != null ? powerData.Attribute("description").Value : ""),
                                         FieldValues = powerData.Descendants("fieldval"),
                                         Tags = powerData.Descendants("tag")
                                     };
                    foreach (var powerData in powersData)
                    {
                        Power power = new Power();
                        power.name = powerData.Name;
                        power.description = powerData.Description;
                        ExtractFieldVals(power, powerData.FieldValues);
                        ExtractTags(power, powerData.Tags);
                        powersList.Add(power);
                    }
                }
                catch
                {
                    Console.WriteLine("Error occured in loading file.");
                }
            }
            return powersList;
        }

        private void ExtractTags(Power power, IEnumerable<XElement> tags)
        {
            foreach (var tag in tags)
            {
                string group = tag.Attribute("group").Value;
                switch (group)
                {
                    case "ReqLevel":
                        power.ReqLevel = GetTag(tag);
                        break;
                    case "ActionType":
                        power.actionType = GetTag(tag);
                        break;
                    case "PowerClass":
                        power.PowerUse = GetTag(tag);
                        break;
                    case "PowerType":
                        power.usage = GetTag(tag);
                        break;
                    case "DamageAttr":
                        power.DamageAttr = GetTag(tag);
                        break;
                    case "Damage":
                        power.Damage = GetTag(tag);
                        break;
                    case "PowerSrc":
                        power.PowerSrc = GetTag(tag);
                        break;
                    case "PowerAcc":
                        power.PowerAcc = GetTag(tag);
                        break;
                    case "AttackType":
                        power.AttackType = GetTag(tag);
                        break;
                    case "Attack":
                        power.attackAttribute = GetTag(tag);
                        break;
                    case "AttackVs":
                        power.AttackVs = GetTag(tag);
                        break;
                    case "PowerUse":
                        power.PowerUse = GetTag(tag);
                        break;
                    case "EffectType":
                        power.EffectType = GetTag(tag);
                        break;
                    case "PowerDest":
                        power.PowerDest = GetTag(tag);
                        break;
                    case "PowerPath":
                        power.PowerPath = GetTag(tag);
                        break;
                    case "DamageType":
                        power.DamageType = GetTag(tag);
                        break;
                    case "RecomClass":
                        power.RecomClass = GetTag(tag);
                        break;
                    case "ReqSkill":
                        power.ReqSkill = GetTag(tag);
                        break;
                    case "PowerLink":
                        power.PowerLink = GetTag(tag);
                        break;
                    case "User":
                        power.User = GetTag(tag);
                        break;
                    case "ConfSource":
                        power.ConfSource = GetTag(tag);
                        break;
                    default:
                        Console.WriteLine("Tag Not Listed: " + group);
                        break;
                }
            }
        }

        private string GetTag(XElement element)
        {
            return element.Attribute("tag").Value;
        }


        private void ExtractFieldVals(Power power, IEnumerable<XElement> fieldValues)
        {
            foreach (var fieldval in fieldValues)
            {
                string field = fieldval.Attribute("field").Value;
                switch (field)
                {
                    case "pwFlavor":
                        power.flavor = GetValue(fieldval);
                        break;
                    case "pwTarget":
                        power.target = GetValue(fieldval);
                        break;
                    case "pwRange1":
                        power.Range1 = GetValue(fieldval);
                        break;
                    case "pwRange2":
                        power.Range2 = GetValue(fieldval);
                        break;
                    case "pwSpecial":
                        power.Special = GetValue(fieldval);
                        break;
                    case "pwRequire":
                        power.Require = GetValue(fieldval);
                        break;
                    case "pwAtkMod":
                        power.attackMod = GetValue(fieldval);
                        break;
                    case "pwAtkExtra":
                        power.atkextra = GetValue(fieldval);
                        break;
                    case "pwDamBase":
                        power.dmgbase = GetValue(fieldval);
                        break;
                    case "spcMax":
                        power.specialmax = GetValue(fieldval);
                        break;
                    default:
                        Console.WriteLine("Tag Not Listed: " + field);
                        break;
                }
            }
        }

        private string GetValue(XElement element)
        {
            return element.Attribute("value").Value;
        }


    }
}
