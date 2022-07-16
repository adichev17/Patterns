using NUnit.Framework;
using Patterns.Observer.SecondExmaple;
using Patterns.Observer.WithEvent;
using Patterns.Observer.WithInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Patterns.Observer.WithEvent.Game;

namespace PattersTests
{
    [TestFixture]
    public class ObserverTests
    {
        [Test]
        public void Test()
        {
            Demo.Start();
        }

        [Test]
        public void PlayingByTheRules()
        {
            Assert.That(typeof(Game).GetFields(), Is.Empty);
            Assert.That(typeof(Game).GetProperties(), Is.Empty);
        }

        [Test]
        public void SingleRatTest()
        {
            var game = new Game();
            var rat = new Rat(game);
            Assert.That(rat.Attack, Is.EqualTo(1));
        }

        [Test]
        public void TwoRatTest()
        {
            var game = new Game();
            var rat = new Rat(game);
            var rat2 = new Rat(game);
            Assert.That(rat.Attack, Is.EqualTo(2));
            Assert.That(rat2.Attack, Is.EqualTo(2));
        }

        [Test]
        public void ThreeRatsOneDies()
        {
            var game = new Game();

            var rat = new Rat(game);
            Assert.That(rat.Attack, Is.EqualTo(1));

            var rat2 = new Rat(game);
            Assert.That(rat.Attack, Is.EqualTo(2));
            Assert.That(rat2.Attack, Is.EqualTo(2));

            using (var rat3 = new Rat(game))
            {
                Assert.That(rat.Attack, Is.EqualTo(3));
                Assert.That(rat2.Attack, Is.EqualTo(3));
                Assert.That(rat3.Attack, Is.EqualTo(3));
            }

            Assert.That(rat.Attack, Is.EqualTo(2));
            Assert.That(rat2.Attack, Is.EqualTo(2));
        }


        //SecondExample
        [Test]
        public void SecondTest()
        {
            var provider = new StockTrader();
            var i1 = new Investor();

            i1.Subscribe(provider);
            var i2 = new Investor();
            i2.Subscribe(provider);
            provider.Trade(new Stock());
            provider.Trade(new Stock());

            Assert.That(provider.Observers.Count, Is.EqualTo(2));
            Assert.Throws<ArgumentNullException>(() => provider.Trade(null));
        }
    }
}
