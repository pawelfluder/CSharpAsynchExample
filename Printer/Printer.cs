using System.Diagnostics;
using System.Reflection;

namespace CSharpAsynchExample.Printer
{
    public class Printer : IPrinter
    {
        private DateTime initialDateTime;
        private readonly string[] headers;
        List<(ConsoleColor, string[])> listOfColorQParts;
        private int[] maxArray;

        public Printer(string[] headers)
        {
            this.headers = headers;
            listOfColorQParts = new List<(ConsoleColor, string[])>();
            var empty = Enumerable.Repeat("", headers.Length).ToArray();

            listOfColorQParts.Add((ConsoleColor.White, headers));
            listOfColorQParts.Add((ConsoleColor.White, empty));
        }

        public void Print()
        {
            Calculate();
            foreach (var item in listOfColorQParts)
            {
                System.Console.ForegroundColor = item.Item1;
                var parts = string.Empty;
                for (int i = 0; i < maxArray.Length; i++)
                {
                    var max = maxArray[i];
                    var tmp = item.Item2[i];
                    var sep = new string(' ', max - tmp.Length + 2);
                    var str = tmp + sep;
                    parts += str;
                }
                System.Console.WriteLine(parts);
            }
        }

        private void Calculate()
        {
            var tmpList = new List<int>();
            for (int i = 0; i < headers.Count(); i++)
            {
                var max = listOfColorQParts.Select(x => x.Item2[i]).Max(x => x.Length);
                tmpList.Add(max);
            }
            maxArray = tmpList.ToArray();
        }

        public void WriteLine(string msg)
        {
            var stackTrace = new StackTrace();
            var methodBase = stackTrace.GetFrame(1).GetMethod();
            WriteLine(MP.Doing, msg, methodBase);
        }

        public void WriteLine(string msg, MethodBase methodBase)
        {
            WriteLine(MP.Doing, msg, methodBase.Name);
        }

        public void WriteLine(MP phaze, string msg, MethodBase methodBase)
        {
            WriteLine(MP.Doing, msg, methodBase.Name);
        }

        public void WriteLine(string msg, string methodName)
        {
            WriteLine(MP.Doing, msg, methodName);
        }

        public void WriteLine(MP phaze, string str05Msg, string str04Method)
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

            // color
            var color = threadId == 1 ? ConsoleColor.White : ConsoleColor.Cyan;

            var parts = new string[] {
                str01Time, str02Thread, str03Phaze, str04Method, str05Msg };
            listOfColorQParts.Add((color, parts));
        }

        public void WriteMethod(MP phaze, MethodBase methodBase)
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
            var name = methodBase.Name;

            // color
            var color = threadId == 1 ? ConsoleColor.White : ConsoleColor.Cyan;

            var parts = new string[] {
                str01Time, str02Thread, str03Phaze, str04Method, "Generated" };
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
