using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Observer.WithInterfaces
{
    public class Event
    {
        // something that can happen
    }

    public class FallsIllEvent : Event
    {
        public string Address;
    }

    public class Person : IObservable<Event>
    {
        public HashSet<Subscription> subscriptions = new HashSet<Subscription>();

        public IDisposable Subscribe(IObserver<Event> observer)
        {
            var subscription = new Subscription(this, observer);
            subscriptions.Add(subscription);
            return subscription;
        }

        public void CatchACold()
        {
            foreach (var sub in subscriptions)
                sub.Observer.OnNext(new FallsIllEvent { Address = "123 London Road" });
        }

        public class Subscription : IDisposable
        {
            private readonly Person person;
            public IObserver<Event> Observer;

            public Subscription(Person person, IObserver<Event> observer)
            {
                this.person = person;
                Observer = observer;
            }

            public void Dispose()
            {
                person.subscriptions.Remove(this);
            }
        }
    }

    public class Demo : IObserver<Event>
    {
        public static void Start()
        {
            new Demo();
        }

        public Demo()
        {
            var person = new Person();
            var sub = person.Subscribe(this);

            person.OfType<FallsIllEvent>()
              .Subscribe(args => Debug.WriteLine($"A doctor has been called to {args.Address}"));
        }

        public void OnNext(Event value)
        {
            if (value is FallsIllEvent args)
                Debug.WriteLine($"A doctor has been called to {args.Address}");
        }

        public void OnError(Exception error) { }
        public void OnCompleted() { }
    }

}
