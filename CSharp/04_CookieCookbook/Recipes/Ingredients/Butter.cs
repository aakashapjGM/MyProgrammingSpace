namespace CookiesCookbook.Recipes.Ingredients
{
    public class Butter : Ingredient
    {
        public override int id => 3;
        public override string name => "Butter";
        public override string PreparationInstruction() => "Melt on low heat.Add to other ingredients";
    }
}
