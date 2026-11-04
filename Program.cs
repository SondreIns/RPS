namespace RPS;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello, RPS");

        // Test zone
        Game game = new Game();
        game.Setup();
        game.DebugPlayerAccess(0).ChangePick();
        game.DebugPlayerAccess(1).ChangePick();
        Console.WriteLine("1: " + game.DebugPlayerAccess(0).Pick);
        Console.WriteLine("2: " + game.DebugPlayerAccess(1).Pick);
        // Exit reached
        Console.WriteLine("exit");
        Console.ReadKey();
    }
}
