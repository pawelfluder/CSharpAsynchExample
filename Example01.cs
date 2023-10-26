using CSharpAsynchExample.ConsolePrinter;
using CSharpAsynchExample.ExampleBase;

namespace CSharpAsynchExample
{
    internal class Example01 : ThreadAnalysis, IExample
    {
        private int ratio = 100;
        public Func<Task> Scenario { get; set; }

        protected override async Task EMain()
        {
            await Run();
        }

        [MethodLogger]
        private async Task Run()
        {
            await Scenario.Invoke();
            Console.WriteLine();
        }

        [MethodLogger]
        public async Task ScenarioOne()
        {
            Console.WriteLine("Scenarion 1:");
            await DoLongWorkAsync();
            await DoShortWorkAsync();
        }

        [MethodLogger]
        public Task ScenarioTwo()
        {
            Console.WriteLine("Scenarion 2:");
            Task.WaitAll(DoLongWorkAsync(), DoShortWorkAsync());
            return default;
        }

        [MethodLogger]
        public async Task ScenarioThree()
        {
            Console.WriteLine("Scenarion 3:");
            Task longWork = DoLongWorkAsync();
            Task shortWork = DoShortWorkAsync();

            Console.WriteLine("Test");

            await longWork;
            await shortWork;
        }

        [MethodLogger]
        private async Task DoShortWorkAsync()
        {
            Console.WriteLine("Started short work.");
            var delay = ratio * 5;
            await Task.Delay(delay);
            Console.WriteLine("Completed short work.");
        }

        [MethodLogger]
        private async Task DoLongWorkAsync()
        {
            Console.WriteLine("Started long work.");
            var delay = ratio * 10;
            await Task.Delay(delay);
            Console.WriteLine("Completed long work.");
        }
    }
}
