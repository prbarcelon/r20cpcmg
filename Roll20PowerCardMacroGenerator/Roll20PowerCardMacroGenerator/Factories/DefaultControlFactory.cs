using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Roll20PowerCardMacroGenerator.Forms.CustomControls;

namespace Roll20PowerCardMacroGenerator.Factory
{

    public class DefaultControlFactory : IMacroControlFactory2
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public DefaultControlFactory()
        {
        }
         
        public IEnumerable<MacroControlBase2> CreateMacroControls(Tag tag)
        {
            var controls = new List<MacroControlBase2>();
            // create requested control
            controls.Add(CreateMacroControl(tag));
            // create controls required by the requested control
            foreach (var id in tag.RequiredTagIDs)
            {   // get required tag
                var t = Settings.Instance.SelectedSystem.PredefinedTags.SingleOrDefault(rt => rt.CustomID == id);
                controls.Add(CreateMacroControl(t)); // create macro control for it
            }
            return controls;
        }

        public MacroControlBase2 CreateMacroControl(Tag tag)
        {
            Type type = Type.GetType(tag.ControlType) ??
                Type.GetType("Roll20PowerCardMacroGenerator.Forms.CustomControls." + tag.ControlType);
            MacroControlBase2 control = null;
            if (type != null)
            {
                control = Activator.CreateInstance(type) as MacroControlBase2;
                if (control != null)
                {
                    control.Init(tag);
                }
                else throw new Exception(string.Format("Failed to create control '{0}'", tag.ControlType));
            }
            else throw new Exception(string.Format("Failed to create control '{0}'", tag.ControlType));

            return control;
        }

        public void InitControl(MacroControlBase2 control, Tag tag)
        {
            control.Init(tag);
        }
    }
}
