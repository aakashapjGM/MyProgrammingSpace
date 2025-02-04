namespace CookiesCookbook.Recipes
{
    public class Recipe
    {
        public IEnumerable<Ingredient> Ingredients {get;}

        public Recipe(IEnumerable<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }

        public override string ToString()
        {
            List<string>  steps = [];

            foreach(var ingredient in Ingredients)
            {
                steps.Add($"{ingredient.name}. {ingredient.PreparationInstruction()}");
            }

            return string.Join(Environment.NewLine, steps);
        }
    }
}
