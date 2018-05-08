using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Roll20PowerCardMacroGenerator
{
    [DataContract]
    public class Tag : ICloneable
    {
        private BindingList<string> _contentValueList;
        private BindingList<string> _requiredTagIDs;
        private BindingList<string> _tagValueList;
        private string _displayName;

        /// <summary>
        /// ID used for reference such as with RequiredTagIDs
        /// </summary>
        //[Required]
        //[Required(true)]
        [Category("Optional")]
        [Description("Description of PropertyB")]
        [DataMember(Order = 0)]
        public string CustomID { get; set; }

        /// <summary>
        /// Tag value
        /// </summary>
        [Category("Required")]
        [DataMember(Order = 1)]
        [DefaultValue("(Insert Tag Here)")]
        public string TagValue { get; set; }

        /// <summary>
        /// Default content value
        /// </summary>
        [Category("Optional")]
        [DataMember(Order = 2)]
        public string ContentValue { get; set; }

        /// <summary>
        /// Tag Control type
        /// </summary>
        [TypeConverter(typeof(StringListConverter))]
        [Category("Required")]
        [DataMember(Order = 3)]
        public string ControlType { get; set; }

        /// <summary>
        /// Default indent level
        /// </summary>
        [Category("Optional")]
        [DataMember(Order = 4)]
        public int IndentLevel { get; set; }

        /// <summary>
        /// Position the tag/content pair should maintain in the !power command
        /// </summary>
        [Category("Optional")]
        [DataMember(Order = 5)]
        public int Position { get; set; }

        /// <summary>
        /// List of content values for the content control
        /// </summary>
        [Category("Optional")]
        [DataMember(Order = 6)]
        public BindingList<string> ContentValueList
        {
            get { return _contentValueList ?? (_contentValueList = new BindingList<string>()); }
            set { _contentValueList = value; }
        }

        /// <summary>
        /// List of required tags ids.
        /// Required tags should be added when this tag is added.
        /// </summary>
        [Category("Optional")]
        [DataMember(Order = 6)]
        public BindingList<string> RequiredTagIDs
        {
            get { return _requiredTagIDs ?? (_requiredTagIDs = new BindingList<string>()); }
            set { _requiredTagIDs = value; }
        }

        /// <summary>
        /// List of values for the Tag controls
        /// </summary>
        [Category("Optional")]
        [DataMember(Order = 7)]
        public BindingList<string> TagValueList
        {
            get { return _tagValueList ?? (_tagValueList = new BindingList<string>()); }
            set { _tagValueList = value; }
        }

        [Category("Optional")]
        [DataMember(Order=8)]
        public string TagDescription { get; set; }

        [Category("Optional")]
        [DataMember(Order = 8)]
        public string DisplayName
        {
            get { return string.IsNullOrEmpty(_displayName) ? TagValue : _displayName; }
            set { _displayName = value; }
        }

        public string IndentString
        {
            get { return IndentLevel == 0 ? "" : "^" + IndentLevel; }
        }

        /// <summary>
        /// Increase the indent value
        /// </summary>
        public void IncreaseIndentation()
        {
            if (IndentLevel < 9)
            {
                IndentLevel++;
            }
        }

        /// <summary>
        /// Decrease the indent value
        /// </summary>
        public void DecreaseIndentation()
        {
            if (IndentLevel > 1)
            {
                IndentLevel--;
            }
        }

        /// <summary>
        /// Obtain the tag/content pair value
        /// </summary>
        /// <returns></returns>
        public string GetMacroEntryString()
        {
            string indentations = "";

            if (IndentLevel > 2)
            {
                indentations = string.Format("^{0}", IndentLevel);
            }
            else if (IndentLevel == 2)
            {
                indentations = "^";
            }
            else
            {
                indentations = "";
            }
            return String.Format("--{0}{1}|{2}", indentations, TagValue, ContentValue);
        }

        #region Parsing

        public static Tag Parse(string inputTag)
        {
            Tag tag = new Tag();
            string[] tokens = inputTag.Trim().Split("|".ToCharArray());
            if (tokens.Length >= 2)
            {
                _parseTagValue(tokens[0], ref tag);
                tag.ContentValue = string.Join("|", tokens.Skip(1));
                tag.CustomID = tag.TagValue;  // for now just assume the TagValue is the ID
                tag.ControlType = "TextBoxControl";      // for now just use a CustomControl to create the macro control
            }
            else throw new FormatException(string.Format("Tag not formatted correctly '{0}'"));
            return tag;
        }

        // allows a tag to start with --; parses the indent value of ^ or ^# where # can be from 1-9
        // sets the Tag.IndentLevel and Tag.TagValue
        private static void _parseTagValue(string tagValue, ref Tag tag)
        {
            Regex regex = new Regex(@"-*(\^\d?)?(.+)");
            string indentMatch = "0";
            string tagMatch = ""; 
            var matches = regex.Matches(tagValue);
            switch (matches.Count)
            {
                case 0:
                    throw new FormatException(string.Format("Tag is not formatted correctly '{0}'", tagValue));
                    break;
                case 1:
                    indentMatch = "0";
                    tagMatch = matches[0].Value;
                    break;
                case 2:
                    indentMatch = matches[0].Length == 1 ? "1" : matches[0].Value[1].ToString();
                    tagMatch = matches[1].Value;
                    break;
                default:
                    throw new FormatException(string.Format("Tag is not formatted correctly '{0}'", tagValue));
            }

            tag.IndentLevel = int.Parse(indentMatch);
            tag.TagValue = tagMatch;
        }

        public static bool TryParse(string inputTag, out Tag t)
        {
            try
            {
                t = Parse(inputTag);
            }
            catch (Exception e)
            {
                t = new Tag();
                return false;
            }
            return true;
        }

        public static MacroParseResults TryParseMacro(string powerCommand, out List<Tag> tags)
        {
            tags = new List<Tag>();
            MacroParseResults results = new MacroParseResults();
            // verify power command is valid and split the command into tokens (token = a tag or '!power')
            if (string.IsNullOrEmpty(powerCommand)) return results;
            if (powerCommand.Trim().StartsWith("!power") == false)
            {
                results.TokenErrors.Add(powerCommand, "The power command must start with '!power'");
                return results;
            }
            else powerCommand = powerCommand.Replace("!power ", "").Trim();
            string[] tokens = powerCommand.Trim().Split(new string[] {"--"}, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length <= 1) return results;
            results.TotalTags = tokens.Length;
            // parse the tags
            foreach (var token in tokens)
            {
                Tag tag;
                if (TryParse(token, out tag))
                {
                    tags.Add(tag);
                    results.ParsedTagCount++;
                }
                else results.TokenErrors.Add(results.TokenErrors.Count + ":" + token, string.Format("Error parsing token '{0}'", token));
            }

            return results;
        }

        #endregion

        public object Clone()
        {
            return new Tag
            {
                CustomID = this.CustomID,
                TagValue = this.TagValue,
                DisplayName = this.DisplayName,
                ContentValue = this.ContentValue,
                ControlType = this.ControlType,
                IndentLevel = this.IndentLevel,
                Position = this.Position,
                TagDescription = this.TagDescription,
                ContentValueList = new BindingList<string>(this.ContentValueList),
                TagValueList = new BindingList<string>(this.TagValueList),
                RequiredTagIDs = new BindingList<string>(this.RequiredTagIDs),
            };
        }
        public override string ToString()
        {
            return string.Format("{0}: --{1}{2}|{3}", CustomID, IndentString, TagValue, ContentValue);
        }
    }

    public class MacroParseResults
    {
        public MacroParseResults()
        {
            TokenErrors = new Dictionary<string, string>();
        }
        public Dictionary<string, string> TokenErrors { get; set; }
        public int TotalTags { get; set; }
        public int ParsedTagCount { get; set; }
        public bool Success { get { return TokenErrors.Count == 0; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Errors: {0}\n", TokenErrors.Count);
            sb.AppendFormat("Parsed: {0}\n", ParsedTagCount);
            sb.AppendFormat("Tags:   {0}\n", TotalTags);
            sb.AppendFormat("Error List:\n");
            sb.AppendFormat(string.Join("\n", TokenErrors.Values));

            return sb.ToString();
        }
    }
}
