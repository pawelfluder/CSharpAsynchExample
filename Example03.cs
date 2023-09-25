using CSharpAsynchExample.Console;
using System.Diagnostics;

namespace CSharpAsynchExample
{
    internal class Example03
    {
        public async Task Main()
        {
            Test1();
        }

        [MethodLogger]
        public async Task<string> ReturnFoo()
        {
            await Task.Delay(3000);

            return "foo";
        }

        [MethodLogger]
        public async Task<string> ReturnFooFoo()
        {
            await Task.Delay(4000);

            return "foofoo";
        }

        public async Task Test1()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            await ReturnFoo();
            await ReturnFooFoo();

            stopWatch.Stop();
            var milliseconds = stopWatch.ElapsedMilliseconds;

            var underFiveSeconds = milliseconds < 5000;

            //Assert.True(underFiveSeconds);
        }


        public async Task Test2()
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
