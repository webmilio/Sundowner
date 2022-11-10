namespace Sundowner.VBScript.Expressions;

public class Dim : Expression
{
    private const string Term = "Dim ";

    public override Expression? Get(string str) => GetSingleKeyword<Dim>(str, Term);
}
