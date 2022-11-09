namespace Sunsetter.Expressions;

public class Declare : Expression
{
    private const string DimTerm = "Dim ";

    internal static string ParseName(string termName, string expression)
    {
        var spaceIndex = expression.IndexOf(termName, StringComparison.OrdinalIgnoreCase) + termName.Length;
        var nameEndIndex = expression.IndexOf(' ', spaceIndex + 1);

        if (nameEndIndex == -1)
            nameEndIndex = expression.Length;

        var name = expression[spaceIndex..nameEndIndex];
        return name;
    }

    public override void Parse(ExpressionFactory actFactory, string expression)
    {
        Audience = new Term(ParseName(DimTerm, expression));
    }

    public override bool Matches(string expression)
    {
        return expression.StartsWith(DimTerm, StringComparison.OrdinalIgnoreCase);
    }
}
