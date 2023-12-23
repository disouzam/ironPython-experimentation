﻿#if !ORIGINALAPP
//#define ORIGINALAPP
#endif

#if !SERIALIZATION1
//#define SERIALIZATION1
#endif

#if !SERIALIZATION2
#define SERIALIZATION2
#endif

namespace HelloWorld;

internal static class Program
{
    static void Main(string[] args)
    {
#if ORIGINALAPP
        var basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
        var scriptFilePath = Path.Combine(basePath.FullName, "PythonScripts", "scriptFile.py");

        var scriptContent = File.ReadAllText(scriptFilePath);

        var eng = IronPython.Hosting.Python.CreateEngine();
        var scope = eng.CreateScope();
        eng.Execute(scriptContent, scope);
        dynamic greetings = scope.GetVariable("greetings");
        System.Console.WriteLine(greetings("world of Iron Python"));
#endif

#if SERIALIZATION1
        Serialization1.Run();
#endif

#if SERIALIZATION2
        Serialization2.Run();
#endif
    }
}
