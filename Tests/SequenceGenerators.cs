using System.Reactive.Linq;

namespace UdemyCourseOne.Tests;

public static class SequenceGenerators
{
    public static void Run()
    {
        IObservable<int> tenToTwenty = Observable.Range(10, 11);
        tenToTwenty.Subscribe(Console.WriteLine);

        IObservable<int> generated = Observable.Generate(
            1,
            i => i <= 100,
            i => i > 1 ? i * i : i + 1,
            i => i
        );
        
        generated.Inspect("Generated");
        
        IObservable<long> interval = Observable.Interval(TimeSpan.FromSeconds(1));
        var timer = Observable.Timer(TimeSpan.FromSeconds(1));
        
        using (interval.Subscribe(Console.WriteLine))
        {
            Console.WriteLine("Press any key to stop");
            Console.ReadKey();
        }
    }
}