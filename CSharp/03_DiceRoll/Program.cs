using System.Linq.Expressions;

namespace _03_DiceRoll;

public class DiceRoll
{
    public static void Main(string[] args)
    {
        Dice dice = new(new Random());
        GuessingGame guessingGame = new(dice);
        GameResult gameResult = guessingGame.Play();
        guessingGame.PrintResult(gameResult);
        
    }
}

public enum GameResult {Victory, Loss}

/*
Program is devided in 2 major section
1. Guessing Game Section
2. Dice (Action item of Guessing Game)
*/

/*
Develpment of Guessing Game
Key Items 
1. User input
2. Dice Roll 
3. Result Print
*/

public class GuessingGame
{
    private Dice _dice;
    private const int initialTries = 3;

    public GuessingGame(Dice dice)
    {
        _dice = dice;
    }

    public GameResult Play()
    {
        var diceRollResult = _dice.Roll();
        Console.WriteLine("Dice Rolled......");

        int triesLeft = initialTries;
        
        while(triesLeft > 0)
        {
            var guess = consoleReader.ReadInteger($"Enter a Number [You have {triesLeft} tries]: ");

            if (guess == diceRollResult)
            {
                return GameResult.Victory;
            }

            triesLeft--;
        }
        return GameResult.Loss;
    }

    public void PrintResult(GameResult result)
    {
        string gameResult = (result == GameResult.Victory) ? "You Win..:)" : "You Loss..:(";
        Console.WriteLine(gameResult);
    }

}

public static class consoleReader
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

/*
Develpment of Action Section Dice
Key Items 
1. random Number Generator
*/

public class Dice
{
    private Random _random;
    private const int SideCount = 6;

    public Dice(Random random)
    {
        _random = random;
    }

    public int Roll() => _random.Next(1, SideCount+1);

    public static void Describe() => Console.WriteLine($"This Guessing Game has 1 Dice with {SideCount} Side");
}