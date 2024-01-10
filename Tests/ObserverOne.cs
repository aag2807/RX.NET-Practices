namespace UdemyCourseOne.Tests;

public sealed class ObserverOne : IObserver<double>
{
    public void OnCompleted()
    {
        Console.WriteLine("The market has completed");
    }

    public void OnError(Exception error)
    {
        Console.WriteLine($"Market had exception {error.Message}");
    }

    public void OnNext(double value)
    {
        Console.WriteLine($"The market produced the new value {value}");
    }
}