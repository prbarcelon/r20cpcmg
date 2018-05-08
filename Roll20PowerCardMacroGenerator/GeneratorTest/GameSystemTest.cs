using System.ComponentModel;
using NUnit.Framework;
using Roll20PowerCardMacroGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roll20PowerCardMacroGenerator.Forms.CustomControls;

namespace GeneratorTest
{
    public class GameSystemTest
    {
        [TestCase]
        public void WriteGameSystemTest()
        {
            GameSystem expected = new GameSystem()
            {
                Name = "Test System",
                PredefinedTags = new List<Tag>()
                {
                    new Tag(){
                        TagValue = "name",
                        ContentValue = "Test Power",
                        IndentLevel = 1,
                        ControlType = "TextBox",
                        ContentValueList = null,
                        Position = 0
                    },
                    new Tag(){
                        TagValue = "attack",
                        ContentValue = "[[0]]",
                        IndentLevel = 1,
                        ControlType = "TextBox",
                    }
                }
            };
            string fileName = "./TestSystem.xml";
            GameSystem.Write(expected, fileName);
            GameSystem actual = GameSystem.Read(fileName);
            Assert.AreEqual(expected.Name, actual.Name);
            for (int i = 0; i < expected.PredefinedTags.Count; i++)
            {
                Tag e = expected.PredefinedTags[i];
                Tag a = actual.PredefinedTags[i];
                Assert.AreEqual(e.TagValue, a.TagValue);
                Assert.AreEqual(e.ContentValue, a.ContentValue);
                Assert.AreEqual(e.IndentLevel, a.IndentLevel);
                Assert.AreEqual(e.ControlType, a.ControlType);
                Assert.AreEqual(e.Position, a.Position);
                Assert.AreEqual(e.ContentValueList, a.ContentValueList);
            }
        }

        [TestCase]
        public void WriteGameSystemTest2()
        {
            GameSystem system = new GameSystem();
            system.PredefinedTags = new List<Tag>();
            system.Name = "DnD4e";
            Tag tag = new Tag();
            tag.CustomID = "name";
            tag.TagValue = "name";
            tag.ContentValue = "default name";
            tag.ControlType = typeof (TextBoxControl).AssemblyQualifiedName;
            tag.RequiredTagIDs = new BindingList<string> { "attack" };
            tag.Position = -1;
            tag.IndentLevel = 0;

            system.PredefinedTags.Add(tag);
            system.PredefinedTags.Add(new Tag
            {
                CustomID = "attack",
                TagValue = "attack",
                ContentValue = "test2",
                ControlType = typeof (ComboBoxControl).AssemblyQualifiedName,
                RequiredTagIDs = new BindingList<string>(),
                Position = -1,
                IndentLevel = 0,
                ContentValueList = new BindingList<string>
                {
                    "test1",
                    "test2",
                    "test3"
                }
            });

            GameSystem.Write(system, system.Name + ".xml");
        }
    }
}
