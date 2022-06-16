using Autofac;
using NUnit.Framework;
using Patterns.Bridge;

namespace PattersTests
{
    [TestFixture]
    public class BridgeTests
    {
        [Test]
        public void Tets()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<VectorRenderer>().As<IRenderer>();
            cb.Register((c, p) => new Circle(c.Resolve<IRenderer>(),
              p.Positional<float>(0)));

            // todo: delegate factories

            using (var c = cb.Build())
            {
                var circle = c.Resolve<Circle>(
                  new PositionalParameter(0, 5.0f)
                );
                circle.Draw();
                circle.Resize(2);
                circle.Draw();

                Assert.That(circle, Is.TypeOf<Circle>());
            }
        }
    }
}
