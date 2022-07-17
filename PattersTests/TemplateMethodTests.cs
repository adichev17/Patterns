using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Patterns.TemplateMethod.Exercise;

namespace PattersTests
{
    [TestFixture]
    public class TemplateMethodTests
    {
        [Test]
        public void ImpasseTest()
        {
            var c1 = new Creature(1, 2);
            var c2 = new Creature(1, 2);
            CardGame game = new TemporaryCardDamageGame(new[] { c1, c2 });
            Assert.That(game.Combat(0, 1), Is.EqualTo(-1));
            Assert.That(game.Combat(0, 1), Is.EqualTo(-1));
        }

        [Test]
        public void TemporaryMurderTest()
        {
            var c1 = new Creature(1, 1);
            var c2 = new Creature(2, 2);
            CardGame game = new TemporaryCardDamageGame(new[] { c1, c2 });
            Assert.That(game.Combat(0, 1), Is.EqualTo(1));
        }

        [Test]
        public void DoubleMurderTest()
        {
            var c1 = new Creature(2, 2);
            var c2 = new Creature(2, 2);
            CardGame game = new TemporaryCardDamageGame(new[] { c1, c2 });
            Assert.That(game.Combat(0, 1), Is.EqualTo(-1));
        }

        [Test]
        public void PermanentDamageDeathTest()
        {
            var c1 = new Creature(1, 2);
            var c2 = new Creature(1, 3);
            CardGame game = new PermanentCardDamage(new[] { c1, c2 });
            Assert.That(game.Combat(0, 1), Is.EqualTo(-1));
            Assert.That(game.Combat(0, 1), Is.EqualTo(1));
        }
    }
}