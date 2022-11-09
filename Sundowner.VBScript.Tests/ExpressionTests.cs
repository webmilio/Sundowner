using Webmilio.Commons.DependencyInjection;
using Sunsetter.Expressions;

namespace Sunsetter.Tests;

[TestClass]
public class ExpressionTests
{
    private readonly ServiceCollection _services = new(false);
    private ExpressionFactory _acts;

    [TestInitialize]
    public void Setup()
    {
        _services.AddSingleton<ExpressionFactory>();
        _acts = _services.GetRequiredService<ExpressionFactory>();
    }

    [TestMethod]
    public void Assign()
    {
        const string Actor = "abc", Audience = "def";

        var act = _acts.ParseAct($"{Audience} = {Actor}");
        act.ValidateSimpleAct(typeof(Assign), Actor, Audience);
    }

    [TestMethod]
    public void Declare()
    {
        const string Audience = "abc";

        var act = _acts.ParseAct($"Dim {Audience} As Integer");
        act.ValidateSimpleAct(typeof(Declare), null, Audience);
    }

    [TestMethod]
    public void Erase()
    {
        const string Audience = "abc";

        var act = _acts.ParseAct($"Erase {Audience} asdasdasdasdasd");
        act.ValidateSimpleAct(typeof(Erase), null, Audience);
    }

    [TestMethod]
    public void Redimension()
    {
        const string Audience = "abc";

        var act = _acts.ParseAct($"ReDim Preserve {Audience}(10, 10, 15)");
        act.ValidateSimpleAct(typeof(Redimension), null, Audience);
    }

    [TestMethod]
    public void MethodCall()
    {
        const string Actor = "ExampleMethod";
        const string Audience = "abc";

        var act = _acts.ParseAct($"{Actor}             ({Audience})");
        act.ValidateSimpleAct(typeof(MethodCall), Actor, Audience);
    }
}

internal static class ActTestsExtensions
{
    public static void ValidateSimpleAct(this Expression act, Type actType, string? actor, string? audience)
    {
        Assert.IsInstanceOfType(act, actType);
        Assert.AreEqual(actor, (act.Actor as Term)?.Content);
        Assert.AreEqual(audience, (act.Audience as Term)?.Content);
    }
}