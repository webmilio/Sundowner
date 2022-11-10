using Sundowner.VBScript.Expressions;
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
        string testFile = "Files/Test.asp";
        string variablesFile = "Files/Variables.txt";

        var lines = File.ReadAllLines(testFile);
        var variables = File.ReadAllLines(variablesFile);

        var expressionFactory = Services.GetRequiredService<ExpressionFactory>();

        List<ExpressionBundle> expressions = new(lines.Length);

        for (int i = 0; i < lines.Length; i++)
        {
            var expression = expressionFactory.Get(lines[i]);

            if (expression != null)
                expressions.Add(new(i + 1, expression));
        }

        expressions.Do(Console.WriteLine);
    }

    public ServiceCollection Services { get; }

    private static void Main(string[] args) => new Program().Start();

    private record ExpressionBundle(int LineIndex, Expression Expression)
    {
        public override string ToString()
        {
            return $"{LineIndex}: {Expression}";
        }
    }
}