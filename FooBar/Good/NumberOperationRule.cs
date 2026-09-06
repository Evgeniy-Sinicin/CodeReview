namespace FooBar.Good;

public sealed class NumberOperationRule : ITransformationRule
{
    private readonly Func<int, int, bool> _operation;
    private readonly int _operand;
    private readonly string _value;

    public NumberOperationRule(
        Func<int, int, bool> operation,
        int operand,
        string value)
    {
        _operation = operation ?? throw new ArgumentNullException(nameof(operation));
        _operand = operand;
        _value = !string.IsNullOrWhiteSpace(value)
            ? value
            : throw new ArgumentException("Value is required.", nameof(value));
    }

    public bool AppliesTo(int number) => _operation(number, _operand);

    public string GetValue() => _value;
}
