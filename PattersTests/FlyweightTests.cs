using NUnit.Framework;
using Patterns.FlyWeight.First_Example;
using Patterns.FlyWeight.Second_Example;

namespace PattersTests
{
    [TestFixture]
    public class FlyweightTests
    {
        [Test]
        public void TestUser2()
        {
            var firstUser = new User2("Nick Diaz");
            var secondUser = new User2("Tom Diaz");

            Assert.That(User2.Strings.Count, Is.EqualTo(3));
        }

        [Test]
        public void FormattedTest()
        {
            var bft = new FormattedText("This is a brave new world");
            bft.GetRange(10, 15).Capitalize = true;

            Assert.That(bft.ToString().Substring(10, 5), Is.EqualTo("BRAVE"));
        }
    }
}
