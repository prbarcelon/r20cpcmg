using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roll20PowerCardMacroGenerator
{
    public class StringListConverter : TypeConverter
    {
        public override bool
        GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true; // display drop
        }
        public override bool
        GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true; // drop-down vs combo
        }
        public override StandardValuesCollection
        GetStandardValues(ITypeDescriptorContext context)
        {
            // note you can also look at context etc to build list
            return new StandardValuesCollection(new string[] { "TextBoxControl", "ComboBoxControl", "CheckedListBoxControl" });
        }
    }
}
