namespace Sundowner.VBScript.Expressions;

public class Assign : Expression
{
    public override Expression? Get(string str)
    {
        var equalsIndex = str.IndexOf('=');

        if (equalsIndex < 0)
            return null;

        // Find leftmost space from equals
        var firstEndIndex = str.LastIndexOf(' ', equalsIndex) - 1;

        if (firstEndIndex >= equalsIndex)
            firstEndIndex = equalsIndex - 1;

        var firstStartIndex = str.LastIndexOf(' ', firstEndIndex - 1);

        if (firstStartIndex < 0)
            firstStartIndex = 0;

        return new Assign()
        {
            First = new(
                firstEndIndex, 
                firstEndIndex - firstStartIndex + 1, 
                str[firstStartIndex..(firstEndIndex + 1)])
        };
    }

    public override int Priority => 10;
}
