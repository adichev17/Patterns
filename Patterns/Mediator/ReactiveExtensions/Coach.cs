using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reflection;
using Autofac;

namespace Patterns.Mediator.ReactiveExtensions
{
    public class Coach
    {
        private IDisposable subscription;
        public int Count { get; private set; } = 0;
        public Coach(EventBroker broker)
        {
            subscription = broker
              .OfType<PlayerScoredEventArgs>()
              .Skip(1)
              .Take(3)
              .Subscribe(args => Count++);
        }
    }
}
