using Roll20PowerCardMacroGenerator.Factory;
using Roll20PowerCardMacroGenerator.Forms.CustomControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Roll20PowerCardMacroGenerator
{
    public class MacroManager
    {
        [DataMember(Order = 0)]
        public List<Tag> SavedTags { get; set; }

        public MacroManager()
        {
            SavedTags = new List<Tag>();
        }

        public void Populate(FlowLayoutPanel panel)
        {
            foreach (MacroControlBase2 control in panel.Controls.OfType<MacroControlBase2>())
            {
                SavedTags.Add(control.TagSettings);
            }
        }

        public void ExtractControls(FlowLayoutPanel panel)
        {
            Control.ControlCollection collection = panel.Controls;
            DefaultControlFactory dcf = new DefaultControlFactory();

            foreach (Tag tag in SavedTags)
            {
                collection.Add(dcf.CreateMacroControl(tag));
            }
        }

        public static void Save(string fileName, MacroManager controls)
        {
            Console.WriteLine("Serializing {0}.", fileName);
            DataContractSerializer ser = new DataContractSerializer(typeof(MacroManager));

            var settings = new XmlWriterSettings { Indent = true };

            using (var writer = XmlWriter.Create(fileName, settings))
            {
                ser.WriteObject(writer, controls);
                writer.Flush();
            }

        }

        public static MacroManager Load(string fileName)
        {
            Console.WriteLine("Deserializing {0}.", fileName);
            FileStream fs = new FileStream(fileName, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(MacroManager));

            MacroManager macroManager = (MacroManager)ser.ReadObject(reader, true);
            reader.Close();
            fs.Close();

            return macroManager;
        }
    }
}
