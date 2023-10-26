using CSharpAsynchExample;

public static class Program
{
    public static void Main(string[] args)
    {
        var e01 = new Example01();
        e01.SetScenario(e01.ScenarioOne).ERun();
        //e01.SetScenario(e01.ScenarioTwo).ERun();
        //e01.SetScenario(e01.ScenarioThree).ERun();

        //new Example04().Run();
        //new Example02().Run();
        //new Example03().Run();

        Console.ReadLine();
    }
}