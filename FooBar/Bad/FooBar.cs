namespace FooBar.Bad;

public class FooBar
{
    public static string FooBarTransform(int elem)
    {
        var result = string.Empty;

        if (elem % 3 == 0)
        {
            result += "foo";
        }

        if (elem % 5 == 0)
        {
            result += "bar";
        }

        return result;
    }
}
