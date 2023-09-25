using CSharpAsynchExample;
using CSharpAsynchExample.Console;
using CSharpAsynchExample.Printer;

public static class Program
{
    public static void Main(string[] args)
    {
        RunExample(new Example02());
    }

    public static async void RunExample(IAsyncExample example)
    {
        var method = "RunExample";
        var headers = new string[] { "Time", "ThId", "Phaze", "Method", "Message" };
        var printer = new Console02(headers);
        MethodLogger.SetConsole(printer);
        example.SetPrinter(printer);
        example.Main();
        printer.WriteLine("After Main()", method);
        Thread.Sleep(1000);
        printer.WriteLine("After Sleep", method);
        printer.Print();
    }
}





//var example03 = new Example03();
//await example03.Main();