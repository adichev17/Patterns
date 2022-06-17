using Patterns.Composite.Models;

namespace Patterns.Composite
{
    public static class CriteriaExtensions
    {
        public static AndSpecification<Product> And(this Color color, Size size)
        {
            return new AndSpecification<Product>(
              new ColorSpecification(color),
              new SizeSpecification(size));
        }
    }
}
