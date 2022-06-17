namespace Patterns.Composite
{
    public abstract class Specification<T>
    {
        public abstract bool IsSatisfied(T p);
        public static Specification<T> operator &(Specification<T> first, Specification<T> second)
        {
            return new AndSpecification<T>(first, second);
        }
    }
}
