using NUnit.Framework;
using Patterns.FlyWeight.First_Example;
using System.Collections.Generic;

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
    }
}
