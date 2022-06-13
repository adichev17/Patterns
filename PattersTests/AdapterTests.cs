using NUnit.Framework;
using Patterns.Adapter.Example;
using Patterns.Adapter.SurrogateProperty;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace PattersTests
{
    [TestFixture]
    public class AdapterTests
    {
        //Adapter with serial. XmlSerial. to Dictionary.
        [Test]
        public void SurrogatePropertyTest() {
            var stats = new CountryStats();
            stats.Capitals.Add("France", "Paris");

            var xs = new XmlSerializer(typeof(CountryStats));
            var stringBuilder = new StringBuilder();
            var stringWriter = new StringWriter(stringBuilder);
            xs.Serialize(stringWriter, stats);
            var newStats = (CountryStats)xs.Deserialize(new StringReader(stringWriter.ToString()));

            Assert.IsNotEmpty(newStats.Capitals);
            Assert.That(newStats.Capitals, Is.TypeOf<Dictionary<string, string>>());
        }

        [Test]
        public void TestAdapter()
        {
            var sq = new Square { Side = 10 };

            var adapter = new SquareToRectangleAdapter(sq);

            Assert.That(adapter.Area(), Is.EqualTo(100));
        }
    }
}
