using CSharpAsynchExample.ConsolePrinter;
using CSharpAsynchExample.ExampleBase;

namespace CSharpAsynchExample.Examples
{
    internal class Example03 : ThreadAnalysis, IAsyncExample
    {
        private int ratio = 1;

        [MethodLogger]
        protected override async Task EMain()
        {
            MethodLogger.WriteLine($"Start Program");

            Task<int> task01 = MAsync01();

            for (int i = 0; i < 5; i++)
            {
                MethodLogger.WriteLine($"Iteration: {i}");
                Task.Delay(ratio * 50).Wait();
            }

            MethodLogger.WriteLine("Wait for task01 termination");
            await task01;

            MethodLogger.WriteLine($"Main end, result = {task01.Result}", "Main");
        }

        [MethodLogger]
        async Task<int> MAsync01()
        {
            for (int i = 0; i < 5; i++)
            {
                MethodLogger.WriteLine($"Iteration: {i}", "MAsync01");
                await Task.Delay(ratio * 100);
            }
            MethodLogger.WriteLine(MP.BeBack, $"After foreach", "MAsync01");
            int result = 123;

            return result;
        }
    }
}
