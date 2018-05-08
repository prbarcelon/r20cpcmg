using NUnit.Framework;
using Roll20PowerCardMacroGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorTest
{
    public static class TagHelper
    {
        public static void CompareTag(Tag expected, Tag actual)
        {
            Assert.AreEqual(expected.TagValue, actual.TagValue);
            Assert.AreEqual(expected.ContentValue, actual.ContentValue);
            Assert.AreEqual(expected.IndentLevel, actual.IndentLevel);
            Assert.AreEqual(expected.ControlType, actual.ControlType);
            Assert.AreEqual(expected.Position, actual.Position);
            Assert.AreEqual(expected.ContentValueList, actual.ContentValueList);
        }
    }
}
