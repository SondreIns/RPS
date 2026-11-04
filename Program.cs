namespace RPS;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello, RPS");

        // Test zone
        Player player1 = new Player(false, 0);
        Player player2 = new Player(false, 1);
        player1.ChangePick();
        player2.ChangePick();
        Console.WriteLine("1: " + player1.Pick);
        Console.WriteLine("2: " + player2.Pick);
        // Exit reached
        Console.WriteLine("exit");
        Console.ReadKey();
    }
}
