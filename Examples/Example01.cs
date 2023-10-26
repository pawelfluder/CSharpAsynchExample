using CSharpAsynchExample.ConsolePrinter;
using CSharpAsynchExample.ExampleBase;

namespace CSharpAsynchExample.Examples
{
    internal class Example01 : ThreadAnalysis, IAsyncExample
    {
        private int ratio = 100;
        public Func<Task> scenario;

        public IAsyncExample SetScenario(Func<Task> s) { scenario = s; return this; }

        [MethodLogger]
        protected override async Task EMain()
        {
            await Run();
        }

        [MethodLogger]
        private async Task Run()
        {
            await scenario.Invoke();
        }

        [MethodLogger]
        public async Task ScenarioOne()
        {
            MethodLogger.WriteLine("Scenarion 1:");
            await DoLongWorkAsync();
            await DoShortWorkAsync();
        }

        [MethodLogger]
        public async Task ScenarioThree()
        {
            MethodLogger.WriteLine("Scenarion 3:");
            Task longWork = DoLongWorkAsync();
            Task shortWork = DoShortWorkAsync();

            await longWork;
            await shortWork;
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
