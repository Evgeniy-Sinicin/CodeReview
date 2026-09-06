namespace FooBar.Good;

public static class FooBarFactory
{
    public static FooBar CreateDefault()
    {
        var operation = (int number, int divisor) => number % divisor == 0;
        return new(
    [
        new NumberOperationRule(operation, 3, "foo"),
        new NumberOperationRule(operation, 5, "bar")
    ]);
    }
}
