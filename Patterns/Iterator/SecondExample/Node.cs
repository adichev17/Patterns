using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Iterator.SecondExample
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Left, Right;
        public Node<T> Parent;

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;

            left.Parent = right.Parent = this;
        }
        public Node(T value)
        {
            Value = value;
        }

        private IEnumerable<Node<T>> Travels(Node<T> current)
        {
            yield return current;
            if (current.Left != null)
            {
                foreach (var left in Travels(current.Left))
                    yield return left;
            }
            if (current.Right != null)
            {
                foreach (var rigth in Travels(current.Right))
                    yield return rigth;
            }
        }

        public IEnumerable<T> PreOrder
        {
            get
            {
                foreach (var node in Travels(this))
                    yield return node.Value;
            }
        }
    }
}
