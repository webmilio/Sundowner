using System.Text;

namespace Sunsetter.Expressions;

public abstract class Expression : Term
{
    public abstract void Parse(ExpressionFactory actFactory, string expression);

    public abstract bool Matches(string expression);

    public Term? Actor { get; set; }
    public Term? Audience { get; set; }

    public override string Content
    {
        get
        {
            StringBuilder sb = new();

            sb.Append(Actor);

            if (Actor != null && Audience != null)
                sb.Append(" -> ");

            sb.Append(Audience);

            return sb.ToString();
        }
    }
}
