using System.Text;

namespace Sundowner.VBScript.Expressions;

public abstract class Expression
{
    public abstract Expression? Get(string str);

    public static T? GetSingleKeyword<T>(string str, string keyword) where T : Expression, new()
    {
        var dimIndex = str.IndexOf(keyword, StringComparison.OrdinalIgnoreCase);

        if (dimIndex < 0)
            return null;

        var dimEndIndex = dimIndex + keyword.Length;
        var variableEnd = str.IndexOf(" ", dimEndIndex + 1, StringComparison.OrdinalIgnoreCase);

        if (variableEnd < 0)
            variableEnd = str.Length;

        return new T()
        {
            First = new(dimIndex + 1, variableEnd - dimEndIndex, str[dimEndIndex..variableEnd])
        };
    }

    public override string ToString()
    {
        StringBuilder sb = new(GetType().Name);

        sb.Append(" (");
        sb.Append(First);

        if (Second != null)
            sb.Append("<-");
        
        sb.Append(Second);
        sb.Append(')');

        return sb.ToString();
    }

    public Term? First { get; init; }
    public Term? Second { get; init; }

    public virtual int Priority => 0;
}