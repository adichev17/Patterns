using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Iterator
{
    public class Creature : IEnumerable<int>
    {
        private int[] stats = new int[3];
        public IEnumerable<int> Stats => stats;

        private const int strength = 0; 
        public int Strength
        {
            get => stats[strength];
            set => stats[strength] = value;
        }

        private const int agility = 1;
        public int Agility
        {
            get => stats[agility];
            set => stats[agility] = value;
        }

        private const int intelligence = 2;
        public int Intelligence
        {
            get => stats[intelligence];
            set => stats[intelligence] = value;
        }

        public double SumOfStats => stats.Sum();
        public double AverageStat => stats.Average();
        public double MaxStat => stats.Max();

        public IEnumerator<int> GetEnumerator()
        {
            return stats.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int this[int index]
        {
            get => stats[index];
            set => stats[index] = value;
        }
    }
}
