namespace Sundowner.VBScript.Expressions;

public class Erase : Expression
{
    private const string Term = "Erase ";

    public override Expression? Get(string str) => GetSingleKeyword<Erase>(str, Term);
}
