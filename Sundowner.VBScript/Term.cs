namespace Sunsetter;

public class Term
{
    public Term() { }
    public Term(string content)
    {
        Content = content;
    }

    public override bool Equals(object? obj)
    {
        return 
            GetType() == obj?.GetType() && 
            obj is Term t && 
            Content.Equals(t.Content);
    }

    public override int GetHashCode()
    {
        return Content.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name} ({Content})";
    }

    public virtual string Content { get; init; }

    public virtual int Priority => 0;
}