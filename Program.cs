using CSharpAsynchExample;
using CSharpAsynchExample.Console;
using CSharpAsynchExample.Printer;

public static class Program
{
    public static void Main(string[] args)
    {
        //RunExample(new Example01());
        RunExample(new Example02());
        //RunExample(new Example03());
    }

    public static async void RunExample(IAsyncExample example)
    {
        var method = "RunExample";
        var headers = new string[] { "Time", "ThId", "Phaze", "Method", "CallStack", "Message" };
        var printer = new Printer(headers);
        MethodLogger.SetPrinter(printer);
        example.Main();
        MethodLogger.WriteLine("After Main()", method);
        Thread.Sleep(1000);
        MethodLogger.WriteLine("After Sleep", method);
        MethodLogger.Print();
    }
}