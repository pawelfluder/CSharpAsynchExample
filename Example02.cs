namespace CSharpAsynchExample
{
    internal class Example02
    {
        private int ratio = 100;

        public async Task Main()
        {
            ConsoleWriteLine($"Start Program");

            Task<int> taskA = MethodAAsync();

            for (int i = 0; i < 5; i++)
            {
                ConsoleWriteLine($" B{i}");
                Task.Delay(ratio*50).Wait();
            }

            ConsoleWriteLine("Wait for taskA termination");

            await taskA;

            ConsoleWriteLine($"The result of taskA is {taskA.Result}");
            Console.ReadKey();
        }

        async Task<int> MethodAAsync()
        {
            for (int i = 0; i < 5; i++)
            {
                ConsoleWriteLine($" A{i}");
                await Task.Delay(ratio*100);
            }
            int result = 123;
            ConsoleWriteLine($" A returns result {result}");
            return result;
        }

        void ConsoleWriteLine(string str)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            Console.ForegroundColor = threadId == 1 ? ConsoleColor.White : ConsoleColor.Cyan;
            Console.WriteLine(
               $"{str}{new string(' ', 26 - str.Length)}   Thread {threadId}");
        }
    }
}
