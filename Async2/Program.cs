namespace Async2;

class Program
{
    static async Task Main()
    {
        Console.WriteLine(Environment.CurrentManagedThreadId);

        await Task1();
        Console.WriteLine(Environment.CurrentManagedThreadId);

        await Task2();
        Console.WriteLine(Environment.CurrentManagedThreadId);

        await Task3();
        Console.WriteLine(Environment.CurrentManagedThreadId);

        await Task4();
        Console.WriteLine(Environment.CurrentManagedThreadId);
    }

    static async Task<int> Task1()
    {
        Console.WriteLine(Environment.CurrentManagedThreadId);
        return await Task.FromResult(1);
    }

    static async Task<int> Task2()
    {
        Console.WriteLine(Environment.CurrentManagedThreadId);
        return 1234;
    }

    static Task<int> Task3()
    {
        Console.WriteLine(Environment.CurrentManagedThreadId);

        int result = Task.Run(() => 1).GetAwaiter().GetResult();
        return Task.FromResult(result);
    }

    static Task<int> Task4()
    {
        Console.WriteLine(Environment.CurrentManagedThreadId);
        return Task.Run(() => 1);
    }
}
