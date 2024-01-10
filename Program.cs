// See https://aka.ms/new-console-template for more information

using System.Dynamic;using System.Reactive.Subjects;
using UdemyCourseOne;
using UdemyCourseOne.Tests;

// #region snippet_Using
    // ObserverOne observer1 = new();
    // Subject<double> subOne = new Subject<double>();
    // subOne.Subscribe(observer1);
    // subOne.OnNext(32);
    //
    // var subscription = subOne.Subscribe(
    //     (val) => Console.WriteLine($"suffered value {val}"),
    //     (error) => Console.WriteLine(error.Message),
    //     () => Console.WriteLine("Completed")
    // );
    //
    // subOne.OnNext(44);
    //
    // subOne.OnCompleted();
    // subscription.Dispose();
    //
    // var sensor = new Subject<double>();
    //
    // using (sensor.Subscribe(val => Console.WriteLine($"received sensor value {val}")))
    // {
    //     sensor.OnNext(1, 2, 3, 4, 10);
    // }
    //
    // sensor.OnNext(5);
    //
    // var market3 = new Subject<double>();
    // var market3Consumer = new Subject<double>();
    //
    // market3.Subscribe(market3Consumer);
    //
    // market3Consumer.Inspect("CONSUMER");
    //
    // market3.OnNext(1, 2, 3, 4, 6);
    //
    //
    // var replayedMarket = new ReplaySubject<double>();
    //
    //
    // replayedMarket.OnNext(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
    // replayedMarket.Subscribe(x => Console.WriteLine($"replayedMarket received {x}"));
    //
    //
    // var marketBehavior = new BehaviorSubject<double>(0.0);
    //
    //
    // marketBehavior.OnNext(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
    //
    // marketBehavior.Subscribe(x => Console.WriteLine($"marketBehavior received {x}"));
    //
    // var asyncSensor  = new AsyncSubject<double>();
    // asyncSensor.Inspect("ASYNC");
    // asyncSensor.OnNext(1, 2);
    // asyncSensor.OnCompleted();
// #endregion

// MarketSubscription.Run();
// CreatingObservables.RUN();
// SequenceGenerators.Run();

ConversionReactive.Run();