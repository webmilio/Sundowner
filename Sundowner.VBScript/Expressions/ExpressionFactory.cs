using Webmilio.Commons.DependencyInjection;
using Webmilio.Commons.Extensions.Reflection;

namespace Sunsetter.Expressions;

[Service]
public class ExpressionFactory
{
    private readonly Expression[] _prototypes;

    public ExpressionFactory()
    {
        _prototypes = AppDomain.CurrentDomain.GetAssemblies()
            .Concrete<Expression>().Create<Expression>()
            .OrderBy(e => e.Priority)
            .ToArray();
    }

    public Expression? FindAct(string expression)
    {
        Expression? act = null;

        for (int i = 0; i < _prototypes.Length && act == null; i++)
        {
            if (_prototypes[i].Matches(expression))
                act = _prototypes[i].GetType().Create<Expression>();
        }

        return act;
    }

    public Expression? ParseAct(string expression)
    {
        var act = FindAct(expression);

        if (act != null)
            act.Parse(this, expression);

        return act;
    }
}
