using CSharpAsynchExample.Printer;

namespace CSharpAsynchExample
{
    public interface IAsyncExample
    {
        Task Main();
        void SetPrinter(Console02 printer);
    }
}
