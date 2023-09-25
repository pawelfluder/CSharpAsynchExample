using System.Reflection;

namespace CSharpAsynchExample.Printer
{
    public interface IPrinter
    {
        void Print();
        void WriteLine(string msg);
        void WriteLine(string msg, string methodName);
        void WriteLine(string msg, MethodBase methodBase);
        void WriteLine(MP phaze, string msg, MethodBase methodBase);
        void WriteLine(MP phaze, string str05Msg, string str04Method);
        void WriteMethod(MP phaze, MethodBase methodBase);
    }
}