namespace Sunsetter.Expressions;

public class Erase : Expression
{
    private const string EraseTerm = "Erase ";

    public override void Parse(ExpressionFactory actFactory, string expression)
    {
        Audience = new Term(Declare.ParseName(EraseTerm, expression));
    }

    public override bool Matches(string expression)
    {
        return expression.StartsWith(EraseTerm, StringComparison.OrdinalIgnoreCase);
    }
}
