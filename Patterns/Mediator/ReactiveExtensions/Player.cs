using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Mediator.ReactiveExtensions
{
    public class Player
    {
        public string Name;
        private int goalsScored;
        private EventBroker broker;
        public delegate Player Factory(string name);

        public Player(string name, EventBroker broker)
        {
            Name = name;
            this.broker = broker;
        }

        public void Score()
        {
            goalsScored++;
            var args = new PlayerScoredEventArgs(Name, goalsScored);
            broker.Publish(args);
        }
    }
}
