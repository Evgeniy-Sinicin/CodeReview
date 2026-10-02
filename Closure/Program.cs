namespace Closure;

class Program
{
    /// <summary>
    /// After compilation the code looks like this
    /// 
    /// class Closure { public int multiplier }
    /// 
    /// var closure = new Closure { multiplier = 2 };
    /// var items2 = items1.Select(x => x * closure.multiplier);
    /// 
    /// closure.multiplier = 3;
    /// </summary>
    static void Main()
    {
        var multiplier = 2;

        var items1 = new int[] { 1, 2, 3 };
        var items2 = items1.Select(x => x * multiplier);

        multiplier = 3;

        foreach (var item in items2)
        {
            Console.WriteLine(item);
        }
    }
}
