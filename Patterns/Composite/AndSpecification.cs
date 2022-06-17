
// combinator
namespace Patterns.Composite
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(params Specification<T>[] items) : base(items)
        {
        }
        public override bool IsSatisfied(T t)
        {
            // Any -> OrSpecification
            return items.All(i => i.IsSatisfied(t));
        }
    }
}
