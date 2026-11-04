using ConsoleHelper;

namespace RPS;

public class Game
{
    private int _roundsToWin = 2;
    private readonly int[] _playerScore = [0, 0];
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

        Console.Clear();
        int winCount;
        ConsoleWriter.WriteLine("Winner must get how many points?", ConsoleColor.Magenta);
        string? input3 = Console.ReadLine();
        if(string.IsNullOrEmpty(input3)) winCount = 2;
        else if (!Int32.TryParse(input3, out int result)) winCount = 2;
        else winCount = result;

        winCount = winCount < 1 ? 1 : winCount > 10 ? 10 : winCount;
        _roundsToWin = winCount;

        Round();
    }

    private void Round()
    {
        while(_playerScore[0] < _roundsToWin && _playerScore[1] < _roundsToWin)
        {
            Pick pick0 = _players[0].SetNewPick();
            Pick pick1 = _players[1].SetNewPick();
            int result = Compare(pick0, pick1);
            string winner = result == 0 ? "Player 1 wins!" : result == 1 ? "Player 2 wins!" : "It's a draw!";
            ConsoleColor col = result ==  0 ? ConsoleColor.Green : result == 1 ? ConsoleColor.Red : ConsoleColor.Yellow;
            if(result == 0) _playerScore[0]++;
            else if (result == 1) _playerScore[1]++;
            ConsoleWriter.WriteLine($"Player 1 picked {pick0}", ConsoleColor.Green);
            ConsoleWriter.WriteLine($"Player 2 picked {pick1}", ConsoleColor.Red);
            ConsoleWriter.WriteLine(winner, col);
            ConsoleWriter.WriteLine($"Score is now {_playerScore[0]} - {_playerScore[1]}", ConsoleColor.Cyan);
            Console.ReadKey();
        }

        ConsoleColor winCol = _playerScore[0] > _playerScore[1] ? ConsoleColor.Green : ConsoleColor.Red;
        string matchWinner = _playerScore[0] > _playerScore[1] ? "1" : "2";
        ConsoleWriter.WriteLine($"Final score is {_playerScore[0]} - {_playerScore[1]}. Player {matchWinner} wins the match!", winCol);

    }

    private int Compare(Pick player1, Pick player2)
    {
        if(player1 == player2) return 2;
        switch(player1)
        {
            case Pick.Rock:
                return player2 == Pick.Paper ? 1 : 0;
            case Pick.Paper:
                return player2 == Pick.Scissors ? 1 : 0;
            case Pick.Scissors:
                return player2 == Pick.Rock ? 1 : 0;
            default:
                return 2;
        }
    }
}