using CSharpAsynchExample;

public static class Program
{
    public static void Main(string[] args)
    {
        var e01 = new Example01();
        e01.Scenario = e01.ScenarioOne;
        //e01.Scenario = e01.ScenarioTwo;
        //e01.Scenario = e01.ScenarioThree;
        e01.ERun();

        //new Example04().Run();
        //new Example02().Run();
        //new Example03().Run();

        Console.ReadLine();
    }
}