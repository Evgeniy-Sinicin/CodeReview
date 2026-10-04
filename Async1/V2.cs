namespace Async1;

class V2
{
    static string result1 = "Init1";
    static string result2 = "Init2";

    internal static void Run()
    {
        DoWork2();
        DoWork1();

        Console.WriteLine(result1);
        Console.WriteLine(result2);
    }

    static async Task DoWork1()
    {
        Thread.Sleep(1000);
        result1 = "Done";
    }

    static async Task DoWork2()
    {
        await Task.Delay(1000);
        result2 = "Done";
    }
}
