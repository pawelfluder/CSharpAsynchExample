using CSharpAsynchExample.ExampleBase;

namespace CSharpAsynchExample
{
    public class Example02 : ThreadAnalysis, IExample
    {
        protected override async Task EMain()
        {
            await Run();
        }

        public static async Task Run()
        {
            string message = "Hello HID!";
            Task<string> echo = EchoAsync(message, 100);
            Console.WriteLine($"Expected echo message: {message}");
            string echoMessage = await echo;
            Console.WriteLine($"Received echo message: {echoMessage}");
        }

        public static async Task<string> EchoAsync(string message, int miliseconds)
        {
            Console.WriteLine($"About to wait for {miliseconds}ms");
            await Task.Delay(miliseconds);
            Console.WriteLine("Finished waiting.");
            return message;
        }
    }
}
