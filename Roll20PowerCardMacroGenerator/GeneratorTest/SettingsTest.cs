using NUnit.Framework;
using Roll20PowerCardMacroGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorTest
{
    public class SettingsTest
    {
        [Test]
        public void LoadGameSystemsTest()
        {
            Settings settings = Settings.Instance;
            Console.WriteLine(settings.GameSystems.Count);
        }
    }
}
