using CSharpAsynchExample.ConsolePrinter;
using CSharpAsynchExample.ExampleBase;

namespace CSharpAsynchExample
{
    internal class Example01b : ThreadAnalysis, IExample
    {
        private int ratio = 100;
        public Action scenario;

        public IExample SetScenario(Action s){ scenario = s; return this; }

        [MethodLogger]
        protected override async Task EMain()
        {
            ERun();
        }

        [MethodLogger]
        private async Task ERun()
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
