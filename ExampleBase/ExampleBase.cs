using CSharpAsynchExample.ConsolePrinter;

namespace CSharpAsynchExample.ExampleBase
{
    public abstract class ThreadAnalysis
    {
        protected abstract Task Main();

        public async void Run()
        {
            var headers = new string[] { "Time", "ThId", "Phaze", "Method", "CallStack", "Message" };
            var printer = new Printer(headers);
            MethodLogger.SetPrinter(printer);
            Main();
            MethodLogger.WriteLine("After Main()", "Run");
            Thread.Sleep(1000);
            MethodLogger.WriteLine("After Sleep", "Run");
            MethodLogger.Print();
        }
    }
}
