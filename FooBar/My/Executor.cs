namespace FooBar.My;

class Executor(IEnumerable<Rule> rules)
{
    public string Execute(int number) => string.Concat(rules.Where(x => x.IsApplicable()).ToList().Select(x => x.Execute()));
}