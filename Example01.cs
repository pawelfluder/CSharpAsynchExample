﻿using CSharpAsynchExample.Printer;

namespace CSharpAsynchExample
{
    internal class Example01 : IAsyncExample
    {
        private int ratio = 1;
        private Console02 printer;

        public async Task Main()
        {
            var task01 = Work01();

            var timeElapsed = 0;
            var interval = ratio*10;
            var name = "Main";
            for (int i = 0; i < 12; i++)
            {
                Task.Delay(ratio * 50).Wait();
                timeElapsed += interval;
                ConsoleWriteLine(name + " :" + timeElapsed);
            }
        }


        public void SetPrinter(Console02 printer)
        {
            this.printer = printer;
        }

        public async Task Work01()
        {
            await Work02();
        }

        public async Task Work02()
        {
            var timeElapsed = 0;
            var interval = ratio * 10;
            var name = "Work02";
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(interval);
                timeElapsed += interval;
                ConsoleWriteLine(name + " :" + timeElapsed);
            }
        }

        void ConsoleWriteLine(string str)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            System.Console.ForegroundColor = threadId == 1 ? ConsoleColor.White : ConsoleColor.Cyan;
            System.Console.WriteLine(
               $"{str}{new string(' ', 26 - str.Length)} Thread {threadId}");
        }

    }
}
