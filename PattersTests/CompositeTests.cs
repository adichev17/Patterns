using NUnit.Framework;
using Patterns.Composite;
using Patterns.Composite.Models;
using System.Linq;

namespace PattersTests
{
    [TestFixture]
    public class CompositeTests
    {
        [Test]
        public void Test()
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);
            Product[] products = { apple, tree, house };
            var bf = new BetterFilter();

            var filterByColor = bf.Filter(products, new ColorSpecification(Color.Green));
            var filterBySize = bf.Filter(products, new SizeSpecification(Size.Large));
            var specificationByLargeGreen = new AndSpecification<Product>(new SizeSpecification(Size.Large), new ColorSpecification(Color.Green));
            var filterByLargeGreen = bf.Filter(products, specificationByLargeGreen);

            Assert.That(filterByColor.Count(), Is.EqualTo(2));
            Assert.That(filterBySize.Count(), Is.EqualTo(2));
            Assert.That(filterByLargeGreen.Count(), Is.EqualTo(1));
        }
    }
}
