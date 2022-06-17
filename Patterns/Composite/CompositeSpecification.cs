using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
