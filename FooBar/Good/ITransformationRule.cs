namespace FooBar.Good;

public interface ITransformationRule
{
    bool AppliesTo(int number);

    string GetValue();
}
