namespace UdemyCourseOne;

public static class ExtensionMethods
{
    public static IDisposable Inspect<T>(this IObservable<T> self, string name)
    {
        return self.Subscribe(
            (val) => Console.WriteLine($"{name} has produced the value {val}"),
            (error) => Console.WriteLine($"{name} has produced an error {error.Message}"),
            () => Console.WriteLine($"{name} has completed")    
        );
    }
    
    public static IObserver<T> OnNext<T> (this IObserver<T> self, params T[] args)
    {
        foreach (var arg in args)
        {
            self.OnNext(arg);
        }

        return self;
    }
}

