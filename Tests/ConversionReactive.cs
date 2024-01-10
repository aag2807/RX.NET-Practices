using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
namespace UdemyCourseOne.Tests;

class Market
{
    private double _price;

    public double Price
    {
        get => _price;
        set => _price = value;
    }

    public void ChangePrice(double newPrice)
    {
        Price = newPrice;
        PriceChanged?.Invoke(this, newPrice);
    }

    public event EventHandler<double> PriceChanged;
}

public static class ConversionReactive
{
    public static void Run()
    {
        LinqOperators();
        // FromEnumerables();
        // FromTasks();
        // FromEvents();
        // StartingUnitOfWork();
    }

    private static void LinqOperators()
    {
        Observable.Range(-10, 21)
            .Select(item => item * item)
            .Distinct();
        
        new List<int> {1,1,2,3,4,4,5,55,}
            .ToObservable()
            .DistinctUntilChanged()
            .Inspect("DistinctUntilChanged");


    }

    private static void FromEnumerables()
    {
        IEnumerable<int> numbers = Enumerable.Range(1, 10);
        IObservable<int> observable = numbers.ToObservable();
        observable.Inspect("FromEnumerables");
    }

    private static void FromTasks()
    {
        Task<string> t = Task.Factory.StartNew(() => "Some work");
        IObservable<string> obs = t.ToObservable();
        obs.Inspect("FromTasks");
    }

    private static void FromEvents()
    {
        Market market = new Market();
        IObservable<EventPattern<double>> priceChanges = Observable.FromEventPattern<double>(
            h => market.PriceChanged += h,
            h => market.PriceChanged -= h
        );

        priceChanges.Subscribe(
            x => Console.WriteLine($"Market price changed to {x.EventArgs}")
        );

        market.ChangePrice(1);
        market.ChangePrice(1.2);
        market.ChangePrice(1.6);
    }

    private static void StartingUnitOfWork()
    {
        IObservable<Unit> start = Observable.Start(() =>
        {
            Console.WriteLine("Starting to do some work");

            Thread.Sleep(3000);

            Console.WriteLine("Finished doing some work");
        });

        start.Inspect("Start");
        Console.ReadKey();
    }
}