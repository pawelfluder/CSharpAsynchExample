using System.Reflection;

namespace CSharpAsynchExample.ConsolePrinter
{
    public interface IPrinter
    {
        void PrintAll();
        void WriteLine(string msg);
        void CollectLine(string msg, string methodName);
        void CollectLine(string msg, MethodBase methodBase);
        void CollectLine(MP phaze, string msg, MethodBase methodBase);
        void CollectLine(MP phaze, string str05Msg, string str04Method);
        void WriteMethod(MP phaze, MethodBase methodBase, string callStack);
    }
}