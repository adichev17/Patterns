using Patterns.Observer.SecondExmaple;

public class StockTrader : IObservable<Stock>
{
    private IList<IObserver<Stock>> observers;
    public IList<IObserver<Stock>> Observers => observers;

    public StockTrader()
    {
        observers = new List<IObserver<Stock>>();
    }

    public IDisposable Subscribe(IObserver<Stock> observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
        return new Unsubscriber(observers, observer);
    }
    public class Unsubscriber : IDisposable
    {
        private IList<IObserver<Stock>> _observers;
        private IObserver<Stock> _observer;
        private bool _disposed = false;

        public Unsubscriber(IList<IObserver<Stock>> observers, IObserver<Stock> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                if (_observer != null && _observers.Contains(_observer))
                {
                    _observers.Remove(_observer);
                }
            }
            _disposed = true;
        }
    }

    public void Trade(Stock stock)
    {
        foreach (var observer in observers)
        {
            if (stock == null)
            {
                observer.OnError(new ArgumentNullException());
            }
            observer.OnNext(stock);
        }
    }
    public void End()
    {
        foreach (var observer in observers.ToArray())
        {
            observer.OnCompleted();
        }
        observers.Clear();
    }
}