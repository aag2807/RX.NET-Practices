using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace UdemyCourseOne.Tests;

public static class Combinators
{
    public static void Run()
    {
        BehaviorSubject<bool> mechanical = new(true);
        BehaviorSubject<bool> electric = new(true);
        BehaviorSubject<bool> electronical = new(true);
        
        mechanical.Amb(electric).Amb(electronical).Inspect("Amb");
        
        mechanical.Inspect("Mechanical");
        electric.Inspect("electric");
        electronical.Inspect("electronical");
        
        mechanical.CombineLatest(electric, electronical, (m, e, el) => m && e && el)
            .Inspect("CombineLatest");
        
        mechanical.OnNext(false);

        var range = Observable.Range(0, 10);
        var letters = Observable.Range(0, 10)
            .Select(x => (char)('A' + x));

        range.Zip(letters, (i, c) => $"{i} - {c}").Inspect("Zipped");
    }
}