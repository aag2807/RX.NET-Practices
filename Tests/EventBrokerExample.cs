using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace UdemyCourseOne.Tests;

public static class EventBrokerExample
{
    public static void RunBroker()
    {
        var broker = new EventBroker();
        new Player(broker, "Sam");
        new Coach(broker);
        
        broker.Publish(new PlayerScoredEvent { Name = "Sam", GoalsScored = 1 });
        broker.Publish(new PlayerScoredEvent { Name = "Sam", GoalsScored = 4 });
    }
}

public class Actor
{
    protected readonly EventBroker broker;

    public Actor(EventBroker broker)
    {
        this.broker = broker ?? throw new Exception("empty broker");
    }
}

public class Player : Actor
{
    public string Name { get; set; } = string.Empty;

    public Player(EventBroker broker, string Name) : base(broker)
    {
        this.Name = Name;
        this.broker.OfType<PlayerScoredEvent>()
            .Subscribe(pe =>
            {
                if (pe.Name != this.Name)
                {
                    Console.WriteLine("{0}: Nicely done, {1}! It's your {2} goal!", this.Name, pe.Name, pe.GoalsScored);
                }
            });
    }
}

public class Coach : Actor
{
    public Coach(EventBroker broker) : base(broker)
    {
        this.broker.OfType<PlayerScoredEvent>()
            .Subscribe(pe =>
            {
                if (pe.GoalsScored < 3)
                {
                    Console.WriteLine("Amazing play {0}", pe.Name);
                }
            });

        this.broker.OfType<PlayerSentOffEvent>()
            .Subscribe(pe =>
            {
                if (pe.Reason == "violence")
                {
                    Console.WriteLine("You're out {0}", pe.Name);
                }
            });
    }
}

public class PlayerEvent
{
    public string Name { get; set; } = string.Empty;
}

public class PlayerScoredEvent : PlayerEvent
{
    public int GoalsScored { get; set; }
}

public class PlayerSentOffEvent : PlayerEvent
{
    public string Reason { get; set; } = string.Empty;
}

public class EventBroker : IObservable<PlayerEvent>
{
    private readonly Subject<PlayerEvent> _subscriptions = new();

    public IDisposable Subscribe(IObserver<PlayerEvent> observer)
    {
        return _subscriptions.Subscribe(observer);
    }

    public void Publish(PlayerEvent playerEvent)
    {
        _subscriptions.OnNext(playerEvent);
    }
}