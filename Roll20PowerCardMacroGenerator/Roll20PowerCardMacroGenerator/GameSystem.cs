using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Roll20PowerCardMacroGenerator
{
    [DataContract]
    public class GameSystem
    {
        [DataMember(Order = 0)]
        public string Name { get; set; }
        [DataMember(Order = 1)]
        public List<Tag> PredefinedTags { get; set; }
        
        public GameSystem()
        {
            
        }

        public static void Write(GameSystem system, string fileName)
        {
            Console.WriteLine(String.Format("Writing Game System \"{0}\" to {1}.", system.Name, fileName));
            DataContractSerializer ser = new DataContractSerializer(typeof(GameSystem));
            
            var settings = new XmlWriterSettings { Indent = true };

            using (var writer = XmlWriter.Create(fileName, settings))
            {
                ser.WriteObject(writer, system);
                writer.Flush();
            }
        }

        public static GameSystem Read(string fileName)
        {
            Console.WriteLine("Deserializing {0}.", fileName);
            FileStream fs = new FileStream(fileName, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(GameSystem));

            GameSystem system = (GameSystem)ser.ReadObject(reader, true);
            reader.Close();
            fs.Close();
            return system;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
