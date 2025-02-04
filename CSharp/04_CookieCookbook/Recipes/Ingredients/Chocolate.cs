namespace CookiesCookbook.Recipes.Ingredients
{
    public class Chocolate : Ingredient
    {
        public override int id => 4;
        public override string name => "Chocolate";
        public override string PreparationInstruction() => "Melt in a water bath. Add to other ingredients.";
    }
}