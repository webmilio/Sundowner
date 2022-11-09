using Sunsetter.Expressions;
using Webmilio.Commons.DependencyInjection;
using Webmilio.Commons.Extensions;

namespace Sunsetter;

internal class Program
{
    public Program()
    {
        Services = new(true);
        Services.AddService(this);
    }

    public void Start()
    {
        string testFile = "Files/CustomerManager.asp";
        string variablesFile = "Files/Variables.txt";

        var lines = File.ReadAllLines(testFile);
        var variables = File.ReadAllLines(variablesFile);

        var expressionFactory = Services.GetRequiredService<ExpressionFactory>();

        List<TermBundle> expressions = new(lines.Length);

        for (int i = 0; i < lines.Length; i++)
        {
            var expression = expressionFactory.ParseAct(lines[i]);

            if (expression != null)
                expressions.Add(new(i, expression));
        }

        expressions.Do(Console.WriteLine);
    }

    public ServiceCollection Services { get; }

    private static void Main(string[] args) => new Program().Start();

    private record TermBundle(int LineIndex, Term Term)
    {
        public override string ToString()
        {
            return $"{LineIndex}: {Term}";
        }
    }
}