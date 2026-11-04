namespace RPS;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello, RPS");

        // Test zone
        Game game = new Game();
        game.StartGame();
        // Exit reached
        Console.WriteLine("exit");
        Console.ReadKey();
    }
}
