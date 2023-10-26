using CSharpAsynchExample.ConsolePrinter;
using System;
using System.Reflection;

namespace CSharpAsynchExample.ExampleBase
{
    public abstract class ThreadAnalysis
    {
        protected abstract Task EMain();

        public async void ERun()
        {
            var headers = new string[] { "Time", "ThId", "Phaze", "Method", "CallStack", "Message" };
            var printer = new Printer(headers);
            MethodLogger.SetPrinter(printer);
            var mainTask = EMain();
            await mainTask;
            MethodLogger.Print();
        }

        //protected MethodInfo GetScenarioByMethodName(string methodName)
        //{
        //    var methodInfo = this.GetType().GetMethod(methodName);
        //    var scenario = () => await methodInfo.Invoke(this, new object[0]);

        //    Func<Task> = 
        //    return methodInfo;
        //}
    }
}
