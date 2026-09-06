namespace FooBar;

class Program
{
    static void Main()
    {
        var number = 0;
        Console.WriteLine(Bad.FooBar.FooBarTransform(number));
        Console.WriteLine(Good.FooBarFactory.CreateDefault().Transform(number));
    }
}
