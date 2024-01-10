using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace UdemyCourseOne.Tests;

public static class Inspecting
{
    public static void Run()
    {
        Subject<int> sub = new Subject<int>();
        sub.Scan(0, ((i, i1) => i + i1)).Inspect("Scan");
        sub.OnNext(1, 2, 3, 4, 5);
    }
}