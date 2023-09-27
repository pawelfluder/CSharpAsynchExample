using CSharpAsynchExample.ConsolePrinter;
using CSharpAsynchExample.ExampleBase;
using System.Diagnostics;

namespace CSharpAsynchExample
{
    internal class Example03 : ThreadAnalysis, IExample
    {
        protected override async Task Main()
        {
            await Test1();
        }

        [MethodLogger]
        private async Task<string> ReturnFoo()
        {
            await Task.Delay(3000);

            return "foo";
        }

        [MethodLogger]
        private async Task<string> ReturnFooFoo()
        {
            await Task.Delay(4000);

            return "foofoo";
        }

        private async Task Test1()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            await ReturnFoo();
            await ReturnFooFoo();

            stopWatch.Stop();
            var milliseconds = stopWatch.ElapsedMilliseconds;

            var underFiveSeconds = milliseconds < 5000;
        }

        private async Task Test2()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            await Task.WhenAll(ReturnFoo(), ReturnFooFoo());

            stopWatch.Stop();
            var milliseconds = stopWatch.ElapsedMilliseconds;

            var underFiveSeconds = milliseconds < 5000;
        }
    }
}
