using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Roll20PowerCardMacroGenerator;

namespace GeneratorTest
{
    public class DataLoaderTest
    {
        [Test]
        public void LoadDataTest()
        {
            DataLoader loader = new DataLoader();
            List<string> kinds = loader.LoadData(@"\Kind.txt");
            foreach(string kind in kinds)
            {
                Console.WriteLine(kind);
            }
            Assert.True(true);
        }

        [Test]
        public void LoadDDIPowersTest()
        {
            DataLoader loader = new DataLoader();
            loader.LoadDDIPowers(@"\Data\ddi_powers.dat");
            Assert.True(true);
        }
    }
}
