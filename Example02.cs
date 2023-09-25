using CSharpAsynchExample.Console;
using CSharpAsynchExample.Printer;

namespace CSharpAsynchExample
{
    internal class Example02 : IAsyncExample
    {
        private int ratio = 1;
        private Console02 printer;

        public Example02()
        {
        }

        [MethodLogger]
        public async Task Main()
        {
            var method = "Main";
            printer.WriteLine($"Start Program", method);

            Task<int> task01 = MAsync01();

            for (int i = 0; i < 5; i++)
            {
                printer.WriteLine($"Iteration: {i}", method);
                Task.Delay(ratio*50).Wait();
            }

            printer.WriteLine("Wait for task01 termination", method);
            await task01;

            printer.WriteLine($"Main end, result = {task01.Result}", method);
        }

        [MethodLogger]
        async Task<int> MAsync01()
        {
            var method = "MAsync01";
            for (int i = 0; i < 5; i++)
            {
                printer.WriteLine($"Iteration: {i}", method);
                await Task.Delay(ratio*100);
            }
            printer.WriteLine(MP.BeBack, $"After foreach", method);
            int result = 123;
            
            return result;
        }

        public void SetPrinter(Console02 printer)
        {
            this.printer = printer;
        }
    }
}
