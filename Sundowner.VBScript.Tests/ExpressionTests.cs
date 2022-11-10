using Webmilio.Commons.DependencyInjection;
using Sundowner.VBScript.Expressions;
using Sunsetter.Expressions;

namespace Sunsetter.Tests;

[TestClass]
public class ExpressionTests
{
    private const string First = "abc", Second = "def";

    private readonly ServiceCollection _services = new(false);
    private ExpressionFactory _exprs;

    [TestInitialize]
    public void Setup()
    {
        _services.AddSingleton<ExpressionFactory>();
        _exprs = _services.GetRequiredService<ExpressionFactory>();
    }

    [TestMethod]
    public void Dim()
    {
        var expr = _exprs.Get($"dIm {First}    AS StrING");
        expr!.ValidateSimpleExpression(typeof(Dim), First, null);
    }

    [TestMethod]
    public void Erase()
    {
        var expr = _exprs.Get($"eRASe {First} asdasdasd");
        expr!.ValidateSimpleExpression(typeof(Erase), First, null);
    }

    [TestMethod]
    public void Assign()
    {
        var expr = _exprs.Get($"{First} = {Second}");
        expr!.ValidateSimpleExpression(typeof(Assign), First, Second);
    }

    //[TestMethod]
    //public void Declare()
    //{
    //    var act = _acts.GetExpression($"Dim {Second} As Integer");
    //    act.ValidateSimpleAct(typeof(Declare), null, Second);
    //}

    //[TestMethod]
    //public void Erase()
    //{
    //    var act = _acts.GetExpression($"Erase {Second} asdasdasdasdasd");
    //    act.ValidateSimpleAct(typeof(Erase), null, Second);
    //}

    //[TestMethod]
    //public void Redimension()
    //{
    //    var act = _acts.GetExpression($"ReDim Preserve {Second}(10, 10, 15)");
    //    act.ValidateSimpleAct(typeof(Redimension), null, Second);
    //}

    //[TestMethod]
    //public void MethodCall()
    //{
    //    const string Actor = "ExampleMethod";

    //    var act = _acts.GetExpression($"{Actor}             ({Second})");
    //    act.ValidateSimpleAct(typeof(MethodCall), Actor, Second);
    //}
}

internal static class ActTestsExtensions
{
    public static void ValidateSimpleExpression(this Expression expr, Type actType, string? first, string? second)
    {
        Assert.IsInstanceOfType(expr, actType);
        Assert.AreEqual(first, expr.First?.Content);
        Assert.AreEqual(second, expr.Second?.Content);
    }
}