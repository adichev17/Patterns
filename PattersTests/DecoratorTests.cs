using NUnit.Framework;
using Patterns.Decorator.FirstExample;
using Patterns.Decorator.SecondExample;
using System;

namespace PattersTests
{
    [TestFixture]
    public class DecoratorTests
    {
        [Test]
        public void Test()
        {
            var circle = new Circle(2);
            var redCircle = new ColoredShape(circle, "red");
            var redHalfTransparentSquare = new TransparentShape(redCircle, 0.5f);

            Assert.That(redHalfTransparentSquare.AsString, Is.EqualTo("A circle of radius 2 has the color red has 50% transparency"));
        }

        [Test]
        public void Test2()
        {
            var dragon = new Dragon(new Bird(), new Lizard());

            dragon.Age = 5;

            Assert.AreEqual(dragon.Fly(), String.Empty);
        }

        [Test]
        public void Test3()
        {
            var dragon = new Dragon(new Bird(), new Lizard());

            dragon.Age = 15;

            Assert.AreNotEqual(dragon.Fly(), String.Empty);
        }
    }
}
