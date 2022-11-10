namespace Sundowner.VBScript.Expressions;

public record Term(int Index, int Length, string Content)
{
    public override string ToString()
    {
        return Content;
    }

    public override int GetHashCode()
    {
        return Content.GetHashCode();
    }
}