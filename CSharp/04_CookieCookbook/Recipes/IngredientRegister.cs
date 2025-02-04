namespace CookiesCookbook.Recipes.Ingredients
{
    public interface IIngredientRegister
    {
        public IEnumerable<Ingredient> All {get;}
        public Ingredient GetById(int id);
    }

    public class IngredientRegister : IIngredientRegister
    {
        public IEnumerable<Ingredient> All {get;} = new List<Ingredient>
        {
            new WheatFlour(),
            new CoconutFlour(),
            new Butter(),
            new Chocolate(),
            new Sugar(),
            new Cardamom(),
            new Cinnamon(),
            new CocoaPowder()
        };

        public Ingredient GetById(int id)
        {
            foreach(var ingredient in All)
            {
                if(ingredient.id == id)
                    return ingredient;
            }

            return null;
        }
    }
}