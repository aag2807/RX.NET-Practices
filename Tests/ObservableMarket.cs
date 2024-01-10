using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace UdemyCourseOne.Tests;

public sealed class ObservableMarket : IObservable<double>
{
    private readonly ICollection<IObserver<double>> _observers = new List<IObserver<double>>();

    public IDisposable Subscribe(IObserver<double> observer)
    {
        _observers.Add(observer);

        return Disposable.Create(() =>
        {
            _observers.Remove(observer);
        });
    }
    
    public void Publish(double value)
    {
        foreach (IObserver<double> observer in _observers)
        {
            observer.OnNext(value);
        }
    }
}

public static class MarketSubscription
{
    public static void Run()
    {
        ObservableMarket market = new ObservableMarket();
        IDisposable sub = market.Inspect("CONSUMER");
        IDisposable sub2 = market.Inspect("CONSUMER2");
        
        market.Publish(123);
        
        IObservable<int> replay =  Observable.Return(123);
        IDisposable sub3 = replay.Inspect("REPLAY");
        
        IObservable<double> empty = Observable.Empty<double>();
        IDisposable sub4 = empty.Inspect("EMPTY");
    }
}