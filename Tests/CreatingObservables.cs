using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace UdemyCourseOne.Tests;

public class CreatingObservables
{
    private static IObservable<string> Blocking()
    {
        var subject = new ReplaySubject<string>();
        subject.OnNext("a", "v", "b");
        subject.OnCompleted();
        Thread.Sleep(3000);

        return subject;
    }

    private static IObservable<string> NonBlocking()
    {
        return Observable.Create<string>(( observer ) =>
        {
            observer.OnNext("a", "v", "b");
            observer.OnCompleted();
            Thread.Sleep(3000);
            return Disposable.Empty;
        });
    }

    public static void RUN()
    {
        NonBlocking().Inspect("NON-BLOCKING");
    }
}