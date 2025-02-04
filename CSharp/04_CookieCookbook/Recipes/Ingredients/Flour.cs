namespace CookiesCookbook.Recipes.Ingredients
{
    public abstract class Flour : Ingredient
    {
        public override string PreparationInstruction() => $"Sieve.{base.PreparationInstruction()}";
    }   
}

