using NUnit.Framework;
using Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattersTests
{
    [TestFixture]
    public class FactoryTests
    {
        [Test]
        public void Test()
        {
            var pf = new PersonFactory();

            var firstPerson = pf.CreatePerson("Dmitriy");
            var secondPerson = pf.CreatePerson("Denis");

            Assert.That(firstPerson.Name, Is.EqualTo("Dmitriy"));
            Assert.That(firstPerson.Id, Is.EqualTo(0));
            Assert.That(secondPerson.Id, Is.EqualTo(1));
        }

        [Test]
        public void FactoryMethodTest()
        {
            var person = SecondPerson.InitPerson("Dmitriy", 20);
            Assert.NotNull(person);
            Assert.That(person, Is.TypeOf<SecondPerson>());
        }
    }

}
