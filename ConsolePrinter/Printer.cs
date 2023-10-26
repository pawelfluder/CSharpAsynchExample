using System.Diagnostics;
using System.Reflection;

namespace CSharpAsynchExample.ConsolePrinter
{
    public class Printer : IPrinter
    {
        private DateTime initialDateTime;
        private readonly string[] headers;
        List<(ConsoleColor, string[])> listOfColorQParts;
        bool printA;
        bool printB;
        bool printC;

        public Printer(string[] headers)
        {
            this.headers = headers;
            listOfColorQParts = new List<(ConsoleColor, string[])>();
            printA = true;
            printB = true;
            printC = true;
        }

        public void SetPrintSetting(string setting)
        {
            if (setting.Length != 3)
            {
                throw new Exception();
            }

            printA = setting[0].Equals('1') ? true : false;
            printB = setting[1].Equals('1') ? true : false;
            printC = setting[2].Equals('1') ? true : false;
        }

        public void PrintAll()
        {
            if (printA)
            {
                var tmp02 = listOfColorQParts.Where(x => x.Item2.Last() != "Generated").ToList();
                Print(tmp02);
            }
            if (printB)
            {
                var tmp01 = listOfColorQParts.Where(x => x.Item2.Last() == "Generated").ToList();
                Print(tmp01);
            }
            if (printC)
            {
                Print(listOfColorQParts);
            }
        }

        public void AddHeader(
            List<(ConsoleColor, string[])> input)
        {
            var empty = Enumerable.Repeat("", headers.Length).ToArray();
            input.Insert(0, (ConsoleColor.White, empty));
            input.Insert(0, (ConsoleColor.White, headers));
            input.Add((ConsoleColor.White, empty));
        }

        private void Print(
            List<(ConsoleColor, string[])> inputList)
        {
            AddHeader(inputList);
            var maxArray = Calculate(inputList);
            foreach (var item in inputList)
            {
                Console.ForegroundColor = item.Item1;
                var parts = string.Empty;
                for (int i = 0; i < maxArray.Length; i++)
                {
                    var max = maxArray[i];
                    var tmp = item.Item2[i];
                    var sep = new string(' ', max - tmp.Length + 2);
                    var str = tmp + sep;
                    parts += str;
                }

                Console.WriteLine(parts);
            }
        }

        private int[] Calculate(
            List<(ConsoleColor, string[])> input)
        {
            var tmpList = new List<int>();
            for (int i = 0; i < headers.Count(); i++)
            {
                var max = input.Select(x => x.Item2[i]).Max(x => x.Length);
                tmpList.Add(max);
            }

            var maxArray = tmpList.ToArray();
            return maxArray;
        }

        public void WriteLine(string msg)
        {
            CollectLine(MP.Doing, msg, "??");
        }

        public void CollectLine(string msg, MethodBase methodBase)
        {
            CollectLine(MP.Doing, msg, methodBase.Name);
        }

        public void CollectLine(MP phaze, string msg, MethodBase methodBase)
        {
            CollectLine(MP.Doing, msg, methodBase.Name);
        }

        public void CollectLine(string msg, string methodName)
        {
            CollectLine(MP.Doing, msg, methodName);
        }

        public void CollectLine(MP phaze, string str05Msg, string str04Method)
        {
            // 01
            var str01Time = GetMiniseconds(DateTime.Now);

            // 02
            int threadId = Thread.CurrentThread.ManagedThreadId;
            var str02Thread = threadId.ToString();

            // 03
            var str03Phaze = GetMethodPhazeMessage(phaze);

            // 04
            // str04Method

            //05
            var stackTrace = new StackTrace();
            var methodBase = stackTrace.GetFrame(3).GetMethod();
            var str05callStack = methodBase.Name;

            // color
            var color = threadId == 1 ? ConsoleColor.White : ConsoleColor.Cyan;

            var parts = new string[] {
                str01Time, str02Thread, str03Phaze, str04Method, str05callStack, str05Msg };
            listOfColorQParts.Add((color, parts));
        }

        public void WriteMethod(MP phaze, MethodBase methodBase, string str05CallStack)
        {
            // 01
            var str01Time = GetMiniseconds(DateTime.Now);

            // 02
            int threadId = Thread.CurrentThread.ManagedThreadId;
            var str02Thread = threadId.ToString();

            // 03
            var str03Phaze = GetMethodPhazeMessage(phaze);

            // 04
            var str04Method = methodBase.Name;

            // 05
            // str05CallStack

            // color
            var color = threadId == 1 ? ConsoleColor.White : ConsoleColor.Cyan;

            var parts = new string[] {
                str01Time, str02Thread, str03Phaze, str04Method, str05CallStack, "Generated" };
            listOfColorQParts.Add((color, parts));
        }

        private string GetMethodPhazeMessage(MP phaze)
        {
            var msg = phaze.ToString();
            return msg;
        }

        private string GetMiniseconds(DateTime dateTime)
        {
            if (initialDateTime == default)
            {
                initialDateTime = DateTime.Now;
            }

            var diff = DateTime.Now - initialDateTime;
            var diffMilliseconds = Math.Ceiling(diff.TotalMilliseconds);


            return diffMilliseconds.ToString();
        }

        private string GetSeconds(DateTime dateTime)
        {
            var hour = dateTime.Hour;
            var minutes = dateTime.Minute;
            var seconds = dateTime.Second;
            var millisec = dateTime.Millisecond;
            var sep = "_";
            var sep2 = ":";

            var result = //hour + sep2 +
                minutes + sep2 + seconds + sep + millisec;
            return result;
        }
    }
}
