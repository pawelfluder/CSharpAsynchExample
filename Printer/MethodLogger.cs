using CSharpAsynchExample.Printer;
using MethodDecorator.Fody.Interfaces;
using System.Diagnostics;
using System.Reflection;

namespace CSharpAsynchExample.Console
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodLogger : Attribute, IMethodDecorator
    {
        private MethodBase methodBase;
        private static IPrinter console;
        private static List<MethodLogger> loggerList = new List<MethodLogger>();

        public MethodLogger()
        {
            loggerList.Add(this);
        }

        public static void Print()
        {
            console.Print();
        }

        public static void WriteLine(string msg)
        {
            var methodName = GetLoggerMethodName();
            console.WriteLine(msg, methodName);
        }

        public static void WriteLine(string msg, string methodName)
        {
            console.WriteLine(msg, methodName);
        }

        public static void WriteLine(string msg, MethodBase methodBase)
        {
            console.WriteLine(msg, methodBase);
        }

        public static void WriteLine(MP phaze, string msg)
        {
            var methodName = GetLoggerMethodName();
            console.WriteLine(phaze, msg, methodName);
        }

        public static void WriteLine(MP phaze, string msg, string methodName)
        {
            console.WriteLine(phaze, msg, methodName);
        }

        public static void WriteLine(MP phaze, string msg, MethodBase methodBase)
        {
            console.WriteLine(phaze, msg, methodBase);
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

        public static void SetPrinter(IPrinter console2)
        {
            console = console2;
        }

        public void Init(object instance, MethodBase methodBase, object[] args)
        {
            this.methodBase = methodBase;
        }

        public void OnEntry()
        {
            console.WriteMethod(MP.Entry, methodBase);
        }

        public void OnExit()
        {
            console.WriteMethod(MP.Exit, methodBase);
        }

        public void OnException(Exception exception)
        {
            console.WriteMethod(MP.Error, methodBase);
        }
    }
}
