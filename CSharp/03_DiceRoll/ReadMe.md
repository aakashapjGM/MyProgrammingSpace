namespace _03_DiceRoll;

public class _03_DiceRoll
{
    public static void Main(string[] args)
    {
        var random = new Random();
        var Dice = new Dice(random);
        var guessingGame = new GuessingGame(Dice);
        GameResult gameResult = guessingGame.Play();
        guessingGame.PrintResult(gameResult);
            
    }
}

public enum GameResult { Victory, Loss }

public class GuessingGame
{
    private Dice _dice;
    private int _diceRollResult;
    public const int initialTries = 3;

    public GuessingGame(Dice dice)
    {
        _dice = dice;
    }

    public GameResult Play()
    {
        _diceRollResult = _dice.Roll();
        Console.WriteLine($"Dice Rolled..");

        var triesLeft = initialTries;
        while(triesLeft > 0)
        {
            var guess = ConsoleReader.ReadInteger($"Enter a Number [Your have {triesLeft} chance]: ");
            if (guess == _diceRollResult)
            {
                return GameResult.Victory;
            }
            --triesLeft;
        }
        return GameResult.Loss;
    }

    public void PrintResult(GameResult gameResult)
    {
        Console.WriteLine((gameResult == GameResult.Victory) ? "You Win.. :)" : $"You Loss.. :(\nDice Rolled Number was {_diceRollResult}");        
    }

}

public static class ConsoleReader
{
    public static int ReadInteger(string message)
    {
        int result;
        do
        {
            Console.WriteLine(message);
        }while(!int.TryParse(Console.ReadLine(), out result));

        return result;
    }
}

public class Dice
{
    private readonly Random _random;
    private const int SideCount = 6 ;

    public Dice(Random random)
    {
        _random = random;
    }
    public int Roll() => _random.Next(1, SideCount+1);
}