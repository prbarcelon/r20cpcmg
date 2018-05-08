using NUnit.Framework;
using Roll20PowerCardMacroGenerator;
using Roll20PowerCardMacroGenerator.Factory;
using Roll20PowerCardMacroGenerator.Forms.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorTest
{
    public class MacroManagerTest
    {
        [Test]
        public void SavedTagsTest()
        {
            Tag t1 = new Tag()
            {
                TagValue = "TestTag1",
                ContentValue = "TestContent1",
                ControlType = "TextBoxControl"
            };

            Tag t2 = new Tag()
            {
                TagValue = "TestTag2",
                ContentValue = "TestContent2",
                ControlType = "TextBoxControl"
            };

            DefaultControlFactory dcf = new DefaultControlFactory();
            MacroManager input = new MacroManager();
            MacroControlBase2 control1 = dcf.CreateMacroControl(t1);
            MacroControlBase2 control2 = dcf.CreateMacroControl(t2);
            input.SavedTags.Add(control1.TagSettings);
            input.SavedTags.Add(control2.TagSettings);
            MacroManager.Save("test.xml", input);
            MacroManager output = MacroManager.Load("test.xml");

            for (int i = 0; i < input.SavedTags.Count; i++)
            {
                Tag expected = input.SavedTags[i];
                Tag actual = output.SavedTags[i];
                TagHelper.CompareTag(expected, actual);
            }
        }

        [Test]
        public void PopulateTest()
        {
            Tag t1 = new Tag()
            {
                TagValue = "TestTag1",
                ContentValue = "TestContent1",
                ControlType = "TextBoxControl"
            };

            Tag t2 = new Tag()
            {
                TagValue = "TestTag2",
                ContentValue = "TestContent2",
                ControlType = "TextBoxControl"
            };

            DefaultControlFactory dcf = new DefaultControlFactory();
            MacroManager input = new MacroManager();
            MacroControlBase2 control1 = dcf.CreateMacroControl(t1);
            MacroControlBase2 control2 = dcf.CreateMacroControl(t2);
            FlowLayoutPanel panel1 = new FlowLayoutPanel();
            panel1.Controls.Add(control1);
            panel1.Controls.Add(control2);
            input.Populate(panel1);

            MacroManager.Save("test.xml", input);
            MacroManager output = MacroManager.Load("test.xml");
            FlowLayoutPanel panel2 = new FlowLayoutPanel();
            output.ExtractControls(panel2);

            for (int i = 0; i < panel2.Controls.Count; i++)
            {
                Tag expected = (panel1.Controls[i] as MacroControlBase2).TagSettings;
                Tag actual = (panel2.Controls[i] as MacroControlBase2).TagSettings;
                TagHelper.CompareTag(expected, actual);
            }
        }
    }
}
