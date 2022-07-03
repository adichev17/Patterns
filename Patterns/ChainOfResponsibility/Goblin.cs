using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.ChainOfResponsibility
{
    public class Goblin : Creature
    {
        public Goblin(Game game) : base(game, 1, 1)
        {
        }
        protected Goblin(Game game, int baseAttack, int baseDefense) : base(game, baseAttack, baseDefense)
        {
        }
        public override void Query(object source, StatQuery sq)
        {
            if (ReferenceEquals(source, this))
            {
                switch (sq.Statistic)
                {
                    case Statistic.Attack:
                        sq.Result += baseAttack;
                        break;
                    case Statistic.Defense:
                        sq.Result += baseDefense;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            } else
            {
                if (sq.Statistic == Statistic.Defense)
                {
                    sq.Result++;
                }
            }
        }
        public override int Defense
        {
            get
            {
                var q = new StatQuery { Statistic = Statistic.Defense };
                foreach (var c in game.Creatures)
                    c.Query(this, q);
                return q.Result;
            }
        }
        public override int Attack
        {
            get
            {
                var q = new StatQuery { Statistic = Statistic.Attack };
                foreach (var c in game.Creatures)
                    c.Query(this, q);
                return q.Result;
            }
        }
    }
}
