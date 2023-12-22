namespace HelloWorld;

internal class Program
{
    static void Main(string[] args)
    {
        var eng = IronPython.Hosting.Python.CreateEngine();
        var scope = eng.CreateScope();
        eng.Execute(
        @"def greetings(name):
                return 'Hello ' + name.title() + '!'
            ", scope);
        dynamic greetings = scope.GetVariable("greetings");
        System.Console.WriteLine(greetings("world of Iron Python"));
    }
}
