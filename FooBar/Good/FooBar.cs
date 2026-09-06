namespace FooBar.Good;

public sealed class FooBar
{
    private readonly IReadOnlyList<ITransformationRule> _rules;

    public FooBar(IEnumerable<ITransformationRule> rules)
    {
        ArgumentNullException.ThrowIfNull(rules);
        _rules = rules.ToArray();
    }

    public string Transform(int number) => string.Concat(
        _rules
            .Where(rule => rule.AppliesTo(number))
            .Select(rule => rule.GetValue()));
}
