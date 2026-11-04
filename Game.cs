using ConsoleHelper;

namespace RPS;

public class Game
{
    private readonly int[] _playerIndex = [0, 1];
    private Player[] _players;
    
    public Game()
    {
        _players = new Player[2];
    }

    public void Setup()
    {
        Console.Clear();
        ConsoleWriter.WriteLine("Player 1, human or computer?", ConsoleColor.Green);
        ConsoleWriter.WriteLine("1. Human\n2. Computer", ConsoleColor.Cyan);
        string? input1 = Console.ReadLine();
        if(string.IsNullOrEmpty(input1)) input1 = "2";

        Console.Clear();
        ConsoleWriter.WriteLine("Player 2, human or computer?", ConsoleColor.Red);
        ConsoleWriter.WriteLine("1. Human\n2. Computer", ConsoleColor.Cyan);
        string? input2 = Console.ReadLine();
        if (string.IsNullOrEmpty(input2)) input2 = "2";

        Player player1 = new Player(!input1.Equals("1"), 0);
        Player player2 = new Player(!input2.Equals("1"), 1);

        _players = [player1, player2];
    }

    public Player DebugPlayerAccess(int index) => _players[index];
}