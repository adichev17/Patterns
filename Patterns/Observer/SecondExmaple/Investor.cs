using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Observer.SecondExmaple
{
    public class Investor : IObserver<Stock>
    {
        public IDisposable unsubscriber;
        public virtual void Subscribe(IObservable<Stock> provider)
        {
            if (provider != null)
            {
                unsubscriber = provider.Subscribe(this);
            }
        }
        public void OnCompleted()
        {
            unsubscriber.Dispose();
        }

        public void OnError(Exception error)
        {
            throw error;
        }

        public void OnNext(Stock value)
        {
           //do
        }
    }
}
