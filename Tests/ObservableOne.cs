using System.Reactive.Disposables;

namespace UdemyCourseOne.Tests;

public sealed class ObservableOne : IObservable<double>
{
    public IDisposable Subscribe(IObserver<double> observer)
    {
        observer.OnNext(2.00f);
        observer.OnCompleted();
        return Disposable.Empty;
    }
}

