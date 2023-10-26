using CSharpAsynchExample.ConsolePrinter;
using CSharpAsynchExample.Examples;

public static class Program
{
    public static async Task Main(string[] args)
    {
        MethodLogger.PrinterSetting = "100"; // "111"

        var e01 = new Example01();
        var e01b = new Example01b();
        await e01.SetScenario(e01.ScenarioOne).ERun();
        await e01b.SetScenario(e01b.ScenarioTwo).ERun();
        await e01.SetScenario(e01.ScenarioThree).ERun();

        //await new Example02().ERun();

        //await new Example03().ERun();

        //await new Example04().ERun();

        Console.ReadLine();
    }
}