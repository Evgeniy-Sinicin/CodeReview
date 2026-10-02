namespace FooBar.My;

class Rule(int number, Predicate<int> condition, Func<int, string> action)
{
    public bool IsApplicable() => condition(number);

    public string Execute() => action(number);
}