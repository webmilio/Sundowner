namespace Sunsetter.Expressions;

public class MethodCall : Expression
{
    public override void Parse(ExpressionFactory actFactory, string expression)
    {
        int paramStartIndex = expression.IndexOf('(');
        var paramEndIndex = expression.IndexOf(')');

        if (paramEndIndex - paramStartIndex > 1)
            Audience = new Term(expression[(paramStartIndex + 1)..(paramEndIndex)]);

        int methodNameEnd = -1;

        for (int i = paramStartIndex - 1; i >= 0 && methodNameEnd == -1; i--)
        {
            if (expression[i] != ' ')
                methodNameEnd = i;
        }

        Actor = new Term(expression[(expression.LastIndexOf(' ', methodNameEnd) + 1)..(methodNameEnd + 1)]);
    }

    public override bool Matches(string expression)
    {
        return expression.Contains("(");
    }

    public override int Priority => 1;
}
