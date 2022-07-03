using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.ChainOfResponsibility
{
    public abstract class Creature
    {
        protected Game game;
        protected readonly int baseAttack;
        protected readonly int baseDefense;

        protected Creature(Game game, int baseAttack, int baseDefense)
        {
            this.game = game;
            this.baseAttack = baseAttack;
            this.baseDefense = baseDefense;
        }
        public virtual int Attack { get; set; }
        public virtual int Defense { get; set; }
        public abstract void Query(object source, StatQuery sq);
    }

    public class Game
    {
        public IList<Creature> Creatures = new List<Creature>();
    }
    public class StatQuery
    {
        public Statistic Statistic;
        public int Result;
    }
    public enum Statistic
    {
        Attack,
        Defense
    }
}
