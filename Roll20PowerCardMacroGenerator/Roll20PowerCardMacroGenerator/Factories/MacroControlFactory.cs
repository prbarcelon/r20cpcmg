using Roll20PowerCardMacroGenerator.Forms.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Roll20PowerCardMacroGenerator.Factories
{
    public class MacroControlFactory : IMacroControlFactory
    {
        public MacroControlFactory()
        {

        }

        public MacroControlBase Create(Tag tag)
        {
            MacroControlBase control;
            Tag tagClone = tag.Clone() as Tag;
            switch (tag.ControlType)
            {
                case "ComboBox":
                    throw new NotImplementedException();
                    break;
                case "CheckedListBox":
                    throw new NotImplementedException();
                    break;
                default:
                    control = new MacroControlTextBox(tagClone);
                    break;
            }

            return control;
        }
    }
}
