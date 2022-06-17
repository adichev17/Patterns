namespace Patterns.Composite
{
    public abstract class CompositeSpecification<T> : Specification<T>
    {
        protected readonly Specification<T>[] items;
        public CompositeSpecification(params Specification<T>[] items)
        {
            this.items = items;
        }
    }
}
