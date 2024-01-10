using System.Reactive.Disposables;
using System.Reactive.Subjects;

namespace UdemyCourseOne.Tests;

public sealed class SubjectOne : ISubject<double>
{
    public void OnCompleted()
    {
        Console.WriteLine("SubjectOne.OnCompleted()");
    }

    public void OnError(Exception error)
    {
        Console.WriteLine("SubjectOne.OnError()");
    }

    public void OnNext(double value)
    {
        Console.WriteLine($"SubjectOne.OnNext({value})");
    }

    public IDisposable Subscribe(IObserver<double> observer)
    {
        return Disposable.Empty;
    }
}