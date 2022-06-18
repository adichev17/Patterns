namespace Patterns.Composite
{
    public abstract class Specification<T>
    {
        public abstract bool IsSatisfied(T p);
    }
}
