using CSharpAsynchExample.ConsolePrinter;
using CSharpAsynchExample.ExampleBase;

namespace CSharpAsynchExample.Examples
{
    internal class Example01b : ThreadAnalysis, IAsyncExample
    {
        private int ratio = 100;
        public Action scenario;

        public IAsyncExample SetScenario(Action s) { scenario = s; return this; }

        [MethodLogger]
        protected override async Task EMain()
        {
            Run();
        }

        [MethodLogger]
        private async Task Run()
        {
            scenario.Invoke();
        }

        [MethodLogger]
        public void ScenarioTwo()
        {
            MethodLogger.WriteLine("Scenarion 2:");
            Task.WaitAll(DoShortWorkAsync(), DoLongWorkAsync());
        }

        [MethodLogger]
        private async Task DoShortWorkAsync()
        {
            MethodLogger.WriteLine("Started short work.");
            var delay = ratio * 5;
            await Task.Delay(delay);
            MethodLogger.WriteLine("Completed short work.");
        }

        [MethodLogger]
        private async Task DoLongWorkAsync()
        {
            MethodLogger.WriteLine("Started long work.");
            var delay = ratio * 10;
            await Task.Delay(delay);
            MethodLogger.WriteLine("Completed long work.");
        }
    }
}
