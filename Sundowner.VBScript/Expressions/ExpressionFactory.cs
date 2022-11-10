using Sundowner.VBScript.Expressions;
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

    public Expression? Get(string str)
    {
        Expression? expression = null;

        for (int i = 0; i < _prototypes.Length && expression == null; i++)
            expression = _prototypes[i].Get(str);

        return expression;
    }
}
