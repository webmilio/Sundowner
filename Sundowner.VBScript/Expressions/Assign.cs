namespace Sunsetter.Expressions;

public class Assign : Expression
{
    public override void Parse(ExpressionFactory actFactory, string expression)
    {
        var parts = expression.Split('=', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        Audience = new Term(parts[0]);
        Actor = new Term(parts[1]);
    }

    public override bool Matches(string expression)
    {
        return expression.Contains('=');
    }
}
