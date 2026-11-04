using ConsoleHelper;

namespace RPS;

public class Player
{
    public bool IsComputer { get; }
    private int _index;

    public Player(bool isComputer, int index)
    {
        IsComputer = isComputer;
        _index = index;
    }

    public Pick SetNewPick()
    {
        bool validPick = false;
        bool error = false;
        if(IsComputer) return (Pick)new Random().Next(0,3);

        while(!validPick)
        {
            Console.Clear();
            if(error) ConsoleWriter.WriteLine("Error - pick must be valid", ConsoleColor.DarkRed);
            ConsoleColor col = _index == 0 ? ConsoleColor.Green : ConsoleColor.Red;
            ConsoleWriter.WriteLine($"Player {_index + 1} pick:", col);
            ConsoleWriter.WriteLine("1. Rock\n2. Paper\n3. Scissors", ConsoleColor.Yellow);
            string? input = Console.ReadLine();
            if(Int32.TryParse(input, out int result))
            {
                if(result <= 3 && result >= 1)
                {
                    error = false;
                    validPick = true;
                    return (Pick)result - 1;
                }
                else error = true;
            }
            else error = true;
            
        }
        return 0;
    }
}