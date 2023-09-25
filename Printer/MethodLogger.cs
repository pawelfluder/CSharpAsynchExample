using CSharpAsynchExample.Printer;
using MethodDecorator.Fody.Interfaces;
using System.Reflection;

namespace CSharpAsynchExample.Console
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
    public class MethodLogger : Attribute, IMethodDecorator
    {
        private MethodBase methodBase;
        private static Console02 console;

        public static void SetConsole(Console02 console2)
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
