# FooBar

This project compares a direct conditional implementation in [`Bad`](Bad) with a rule-based version in [`Good`](Good).

## Business rule

- A number divisible by `3` produces `"foo"`.
- A number divisible by `5` produces `"bar"`.
- A number divisible by both produces `"foobar"`.
- A number divisible by neither produces an empty string.

## Bad

`Bad/FooBar.cs` directly checks divisibility by `3` and `5`.

```csharp
if (number % 3 == 0) { ... }
if (number % 5 == 0) { ... }
```

It is appropriate for a small, fixed exercise. Adding a new type of rule requires changing the `FooBar` class.

## Good

`Good/FooBar.cs` depends on `ITransformationRule`, not on a specific operation.

```text
FooBar
  -> ITransformationRule
      -> NumberOperationRule
```

`NumberOperationRule` receives a predicate, operand, and output value:

```csharp
var operation = (int number, int divisor) => number % divisor == 0;

var fooBar = new FooBar.Good.FooBar(
[
    new NumberOperationRule(operation, 3, "foo"),
    new NumberOperationRule(operation, 5, "bar")
]);
```

New rules can be added without modifying `FooBar`:

```csharp
new NumberOperationRule(
    (number, multiplier) => number * multiplier > 100,
    3,
    "baz")
```

`NumberOperationRule` validates its operation and output value. The rule-based approach is useful when rules are configurable or expected to grow. For permanently fixed `% 3` and `% 5` conditions, the direct version is simpler.

## Build

```powershell
dotnet build FooBar.csproj
```
