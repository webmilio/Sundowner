namespace Sunsetter;

internal class StringHelpers
{
    public static bool StartsWith(string str, string value)
    {
        return str.TrimStart().StartsWith(value, StringComparison.OrdinalIgnoreCase);
    }
}
