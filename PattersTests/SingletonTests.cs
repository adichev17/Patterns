using Autofac;
using NUnit.Framework;
using Patterns.Singleton.SingletonWithDI;
using Patterns.Singleton.WingletonWithLazyLoad;

namespace PattersTests
{
    [TestFixture]
    public class SingletonTests
    {
        private IContainer container;

        [SetUp]
        public void Setup()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<SingletonDatabaseWithDI>()
                .As<IDatabase>()
                .SingleInstance(); // <-- with DI

            container = cb.Build();
        }

        //Custom Lazy Load
        [Test]
        public void Test()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;

            Assert.That(db, Is.SameAs(db2));
            Assert.That(db.GetPopulatin(), Is.EqualTo(33200000));
        }

        //With DI
        [Test]
        public void TestSecond()
        {
            var db = container.Resolve<IDatabase>();
            var db2 = container.Resolve<IDatabase>();

            Assert.That(db, Is.SameAs(db2));
        }
    }
}
