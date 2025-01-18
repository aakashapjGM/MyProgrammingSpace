namespace _03_DiceRoll
{
    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }
    public class DiceRoll
    {
        public static void Main(string[] args)
        {
            
            var random = new Random();

            for(var i=0; i<10; i++)
            {
                Console.WriteLine(new Dice(random).Roll());
            }
            
        }
    }

    public class Dice
    {
        private readonly Random _random;
        private int _SideCount;

        public Dice(Random random, int numberOfSides = 6)
        {
            _random = random;
            _SideCount = numberOfSides;
        }
        public int Roll() 
        {
            var random = new Random();
            return random.Next(1, _SideCount + 1);
        }
    }
}