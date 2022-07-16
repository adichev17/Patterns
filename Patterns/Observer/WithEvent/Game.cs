using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Observer.WithEvent
{
    public class Game
    {
        public event EventHandler RatEnters, RatDies;
        public event EventHandler<Rat> NotifyRat;

        public void FireRatEnters(object sender)
        {
            RatEnters?.Invoke(sender, EventArgs.Empty);
        }

        public void FireRatDies(object sender)
        {
            RatDies?.Invoke(sender, EventArgs.Empty);
        }

        public void FireNotifyRat(object sender, Rat whichRat)
        {
            NotifyRat?.Invoke(sender, whichRat);
        }

        public class Rat : IDisposable
        {
            private readonly Game game;
            public int Attack = 1;

            public Rat(Game game)
            {
                this.game = game;
                game.RatEnters += (sender, args) =>
                {
                    if (sender != this)
                    {
                        ++Attack;
                        game.FireNotifyRat(this, (Rat)sender);
                    }
                };
                game.NotifyRat += (sender, rat) =>
                {
                    if (rat == this) ++Attack;
                };
                game.RatDies += (sender, args) => --Attack;
                game.FireRatEnters(this);
            }


            public void Dispose()
            {
                game.FireRatDies(this);
            }
        }
    }
}
