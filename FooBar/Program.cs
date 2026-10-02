using FooBar.My;

namespace FooBar;

class Program
{
    static void Main()
    {
        var number = 0;
        Console.WriteLine($"Bad Solution Result: {Bad.FooBar.FooBarTransform(number)}");
        Console.WriteLine($"Good Solution Result: {Good.FooBarFactory.CreateDefault().Transform(number)}");

        var executor = new Executor(
        [
            new Rule(number, x => x % 2 == 0, x => "foo"),
            new Rule(number, x => x % 3 == 0, x => "bar")
        ]);
        Console.WriteLine($"My Solution Result: {executor.Execute(number)}");
    }
}
