using MethodDecorator.Fody.Interfaces;
using System.Diagnostics;
using System.Reflection;

namespace CSharpAsynchExample.ConsolePrinter
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodLogger : Attribute, IMethodDecorator
    {
        private MethodBase methodBase;
        private static IPrinter printer;
        private static List<MethodLogger> loggerList = new List<MethodLogger>();

        public MethodLogger()
        {
            loggerList.Add(this);
        }

        public static void PrintCollected()
        {
            printer.PrintAll();
        }

        public static void RealPrint(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void WriteLine()
        {
            RealPrint("");
        }

        public static void WriteLine(string msg)
        {
            var methodName = GetLoggerMethodName();
            printer.CollectLine(msg, methodName);
            RealPrint(msg);
        }

        public static void WriteLine(string msg, string methodName)
        {
            printer.CollectLine(msg, methodName);
        }

        public static void WriteLine(string msg, MethodBase methodBase)
        {
            printer.CollectLine(msg, methodBase);
        }

        public static void WriteLine(MP phaze, string msg)
        {
            var methodName = GetLoggerMethodName();
            printer.CollectLine(phaze, msg, methodName);
        }

        public static void WriteLine(MP phaze, string msg, string methodName)
        {
            printer.CollectLine(phaze, msg, methodName);
        }

        public static void WriteLine(MP phaze, string msg, MethodBase methodBase)
        {
            printer.CollectLine(phaze, msg, methodBase);
        }

        private static MethodBase GetMethod()
        {
            var stackTrace = new StackTrace();
            var methodList = stackTrace.GetFrames().Select(x => x.GetMethod()).ToList();
            methodList.RemoveRange(0, 2);
            methodList.RemoveAll(x => x.Name == "Start" || x.Name == "MoveNext");
            var methodBase = methodList.ElementAt(0);

            var temp = loggerList.Where(x => x.methodBase.Name == methodBase.Name);
            var logger = temp.ElementAt(0);
            return logger.methodBase;
        }

        private static string GetLoggerMethodName()
        {
            var stackTrace = new StackTrace();
            var methodList = stackTrace.GetFrames().Select(x => x.GetMethod()).ToList();
            methodList.RemoveRange(0, 2);
            methodList.RemoveAll(x => x.Name == "Start" || x.Name == "MoveNext");
            var firstMethodBase = methodList.ElementAt(0);

            var temp = loggerList.Where(x => x.methodBase.Name == firstMethodBase.Name);
            if (temp.Count() == 1)
            {
                var name = temp.ElementAt(0).methodBase.Name;
                return name;
            }

            return "??";
        }

        public static void SetPrinter(IPrinter inputPrinter)
        {
            printer = inputPrinter;
        }

        private string GetCallStackMethodName()
        {
            var stackTrace = new StackTrace();
            var methodBase = stackTrace.GetFrame(2).GetMethod();
            var callStack = methodBase.Name;
            return callStack;
        }

        public void Init(object instance, MethodBase methodBase, object[] args)
        {
            this.methodBase = methodBase;
        }

        public void OnEntry()
        {
            var callStack = GetCallStackMethodName();
            printer.WriteMethod(MP.Entry, methodBase, callStack);
        }

        public void OnExit()
        {
            var callStack = GetCallStackMethodName();
            printer.WriteMethod(MP.Exit, methodBase, callStack);
        }

        public void OnException(Exception exception)
        {
            var callStack = GetCallStackMethodName();
            printer.WriteMethod(MP.Error, methodBase, callStack);
        }
    }
}
