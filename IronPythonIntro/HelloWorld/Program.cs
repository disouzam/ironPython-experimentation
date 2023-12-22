using System.Reflection;

namespace HelloWorld;

internal class Program
{
    static void Main(string[] args)
    {
        var basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
        var scriptFilePath = Path.Combine(basePath.FullName, "scriptFile.py");

        var scriptContent = File.ReadAllText(scriptFilePath);

        var eng = IronPython.Hosting.Python.CreateEngine();
        var scope = eng.CreateScope();
        eng.Execute(scriptContent, scope);
        dynamic greetings = scope.GetVariable("greetings");
        System.Console.WriteLine(greetings("world of Iron Python"));
    }
}
