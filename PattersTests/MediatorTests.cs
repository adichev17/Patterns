using Autofac;
using NUnit.Framework;
using Patterns.Mediator.ReactiveExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattersTests
{
    [TestFixture]
    public class MediatorTests
    {
        [Test]
        public void Test()
        {
            //Arrange
            var cb = new ContainerBuilder();
            cb.RegisterType<EventBroker>().SingleInstance();
            cb.RegisterType<Player>();
            cb.RegisterType<Coach>();

            var container = cb.Build();

            var pf = container.Resolve<Player.Factory>();
            var player = pf("John");

            var coach = container.Resolve<Coach>();

            //Act

            player.Score();
            player.Score();
            player.Score();
            player.Score(); 
            player.Score();

            //Assert
            Assert.That(coach.Count, Is.EqualTo(3));
        }
    }
}
