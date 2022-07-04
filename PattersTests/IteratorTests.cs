using NUnit.Framework;
using Patterns.Iterator;
using Patterns.Iterator.SecondExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattersTests
{
    [TestFixture]
    public class IteratorTests
    {
        [Test]
        public void Iterator_Creature_Test()
        {
            var creature = new Creature();

            creature.Agility = 10;
            creature.Intelligence = 20;
            creature.Strength = 30;

            Assert.That(creature.SumOfStats, Is.EqualTo(60));
            Assert.That(creature.AverageStat, Is.EqualTo(20));
            Assert.That(creature.MaxStat, Is.EqualTo(30));
        }
        
        [Test]
        public void Iterator_Node_Test()
        {
            var node = new Node<char>('a',
                new Node<char>('b',
                    new Node<char>('c'),
                    new Node<char>('d')),
                new Node<char>('e'));

            Assert.That(new string(node.PreOrder.ToArray()), Is.EqualTo("abcde"));
        }
    }
}
