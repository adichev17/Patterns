using NUnit.Framework;
using System;
using static Patterns.Builder.Builder;

namespace PattersTests
{
    [TestFixture]
    public class BuilderTests
    {
        private static string Preprocess(string s)
        {
            return s.Trim().Replace("\r\n", "\n");
        }
        [Test]
        public void EmptyTest()
        {
            var cb = new CodeBuilder("Foo");
            Assert.That(Preprocess(cb.ToString()), Is.EqualTo("public class Foo\n{\n}"));
        }
        [Test]
        public void PersonText()
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Assert.NotNull(cb);
        }
    }
}