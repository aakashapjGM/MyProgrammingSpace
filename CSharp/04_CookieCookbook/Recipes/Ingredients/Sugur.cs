namespace CookiesCookbook.Recipes.Ingredients
{
    public class Sugar : Ingredient
    {
        public override int id => 5;
        public override string name => "Sugar";
        public override string PreparationInstruction() => "Add to other ingredients.";
    }
}
