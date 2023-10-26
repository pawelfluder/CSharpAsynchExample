using CSharpAsynchExample.ConsolePrinter;

namespace CSharpAsynchExample.ExampleBase
{
    public abstract class ThreadAnalysis
    {
        protected abstract Task EMain();

        public bool PrintCollected { get; internal set; }

        public async Task ERun()
        {
            var headers = new string[] { "Time", "ThId", "Phaze", "Method", "CallStack", "Message" };
            var printer = new Printer(headers);
            MethodLogger.SetPrinter(printer);
            printer.SetPrintSetting(MethodLogger.PrinterSetting);
            var mainTask = EMain();
            await mainTask;
            MethodLogger.RealPrint("");
            MethodLogger.PrintCollected();
        }
    }
}
