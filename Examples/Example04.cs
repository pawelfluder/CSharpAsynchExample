using CSharpAsynchExample.ConsolePrinter;
using CSharpAsynchExample.ExampleBase;

namespace CSharpAsynchExample.Examples
{
    internal class Example04 : ThreadAnalysis, IAsyncExample
    {
        private int ratio = 1;

        protected override async Task EMain()
        {
            var task01 = Work01();

            var timeElapsed = 0;
            for (int i = 0; i < 10; i++)
            {
                var delay = ratio * 10;
                Task.Delay(delay).Wait();
                timeElapsed += delay;
                MethodLogger.WriteLine("timeElapsed01 :" + timeElapsed, "Main");
            }
        }

        private async Task Work01()
        {
            await Work02();
        }

        private async Task Work02()
        {
            var timeElapsed = 0;
            for (int i = 0; i < 10; i++)
            {
                var delay = ratio * 10;
                await Task.Delay(delay);
                timeElapsed += delay;
                MethodLogger.WriteLine("timeElapsed02 :" + timeElapsed, "Work02");
            }
        }
    }
}
