using CSharpAsynchExample.ConsolePrinter;
using CSharpAsynchExample.ExampleBase;

namespace CSharpAsynchExample.Examples
{
    public class Example02 : ThreadAnalysis, IAsyncExample
    {
        [MethodLogger]
        protected override async Task EMain()
        {
            await Run();
        }

        [MethodLogger]
        public static async Task Run()
        {
            string message = "Hello HID!";
            Task<string> echo = EchoAsync(message, 100);
            MethodLogger.WriteLine($"Expected echo message: {message}");
            string echoMessage = await echo;
            MethodLogger.WriteLine($"Received echo message: {echoMessage}");
        }

        [MethodLogger]
        public static async Task<string> EchoAsync(string message, int miliseconds)
        {
            MethodLogger.WriteLine($"About to wait for {miliseconds}ms");
            await Task.Delay(miliseconds);
            MethodLogger.WriteLine("Finished waiting.");
            return message;
        }
    }
}
