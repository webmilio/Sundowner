namespace Sunsetter.Expressions;

public class Redimension : Expression
{
    public override void Parse(ExpressionFactory actFactory, string expression)
    {
        var parentheseIndex = expression.IndexOf('(');
        var name = expression[(expression.LastIndexOf(' ', parentheseIndex) + 1)..parentheseIndex];

        Audience = new Term(name);
    }

    public override bool Matches(string expression)
    {
        return expression.StartsWith("Redim ", StringComparison.OrdinalIgnoreCase);
    }
}
