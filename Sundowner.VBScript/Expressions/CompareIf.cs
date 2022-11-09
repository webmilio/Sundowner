namespace Sunsetter.Expressions;

public class CompareIf : Expression
{
    private const string IfTerm = "If ";
    private const string ThenTerm = " Then";

    public override void Parse(ExpressionFactory actFactory, string expression)
    {
        var parsing = new string(expression);

        var ifIndex = parsing.IndexOf(IfTerm);
        var thenIndex = parsing.IndexOf(ThenTerm);

        parsing = parsing[(ifIndex + IfTerm.Length)..(thenIndex)];
        Term? innerExpression = actFactory.ParseAct(parsing);

        if (innerExpression == null)
            innerExpression = new Term(parsing);

        Audience = innerExpression;
    }

    public override bool Matches(string expression)
    {
        return expression.StartsWith("If ", StringComparison.OrdinalIgnoreCase);
    }

    public override int Priority => -1;
}
