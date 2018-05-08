using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using Roll20PowerCardMacroGenerator.Factories;
using Roll20PowerCardMacroGenerator.Factory;

namespace Roll20PowerCardMacroGenerator
{
    [DataContract]
    public sealed class Settings
    {
        private static readonly Lazy<Settings> lazy = new Lazy<Settings>(Load);

        public static Settings Instance { get { return lazy.Value; } }

        public List<GameSystem> GameSystems;
        private IMacroControlFactory2 _macroControlFactory;
        private ITagButtonFactory _tagButtonFactory;

        [DataMember]
        public string SelectedSystemName { get; set; }

        public GameSystem SelectedSystem
        {
            get
            {
                return GameSystems.FirstOrDefault(gs => gs.Name == SelectedSystemName) ?? GameSystems.FirstOrDefault();
            }
            set { SelectedSystemName = value.Name; }
        }

        public IMacroControlFactory2 MacroControlFactory
        {
            get { return _macroControlFactory; }
            set
            {
                _macroControlFactory = value;
                IMacroControlFactoryType = value.GetType().AssemblyQualifiedName;
            }
        }

        public ITagButtonFactory TagButtonFactory
        {
            get { return _tagButtonFactory; }
            set
            {
                _tagButtonFactory = value;
                ITagButtonFactoryType = value.GetType().AssemblyQualifiedName;
            }
        }

        [DataMember]
        public string IMacroControlFactoryType { get; set; }

        [DataMember]
        public string ITagButtonFactoryType { get; set; }

        private Settings()
        {

        }

        private void LoadGameSystems()
        {
            GameSystems = new List<GameSystem>();
            string[] fileNames = Directory.GetFiles("./Data/GameSystems","*.xml");
            foreach (string fileName in fileNames)
            {
                GameSystems.Add(GameSystem.Read(fileName));
            }

        }

        public void ReloadGameSystems()
        {
            GameSystems.Clear();
            LoadGameSystems();
        }

        private void LoadFactories()
        {
            MacroControlFactory = LoadMacroControlFactory(IMacroControlFactoryType, new DefaultControlFactory());
            TagButtonFactory = LoadMacroControlFactory(ITagButtonFactoryType, new DefaultTagButtonFactory());
        }

        /// <summary>
        /// Loads a factory of the type specified
        /// </summary>
        /// <typeparam name="T">Type of the factory</typeparam>
        /// <param name="typeName">Assembly qualified type name</param>
        /// <param name="defaultVal">default factory if the typename fails to load</param>
        /// <returns>Factory of type T</returns>
        public static T LoadMacroControlFactory<T>(string typeName, T defaultVal) where T : class
        {
            T factory = null;
            try
            {
                Type type = Type.GetType(typeName);
                if(type != null)
                    factory = Activator.CreateInstance(type) as T;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return factory ?? defaultVal;
        }

        public void Save()
        {
                DataContractSerializer ser = new DataContractSerializer(typeof(Settings));

                var settings = new XmlWriterSettings { Indent = true };

                using (var writer = XmlWriter.Create("settings.xml", settings))
                {
                    ser.WriteObject(writer, this);
                    writer.Flush();
                }
        }

        public static Settings Load()
        {
            Settings _settings = null;
                try
                {
                    using (FileStream fs = new FileStream("settings.xml", FileMode.Open))
                    {
                        XmlDictionaryReader reader =
                            XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                        DataContractSerializer ser = new DataContractSerializer(typeof (Settings));

                        // Deserialize the data and read it from the instance.
                        _settings =
                            (Settings) ser.ReadObject(reader, true);
                        reader.Close();
                        _settings.LoadGameSystems();
                        _settings.LoadFactories();
                    }
                }
                catch (Exception e)
                {
                    _settings = new Settings();
                    _settings.LoadGameSystems();
                    _settings.LoadFactories();
                }
            return _settings;
        }
    }
}
