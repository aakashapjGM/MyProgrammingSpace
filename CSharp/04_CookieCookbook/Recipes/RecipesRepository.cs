using CookiesCookbook.Recipes.Ingredients;
using CookiesCookbook.Recipes.StringRepository;
namespace CookiesCookbook.Recipes.RecipesRepository
{
    public interface IRecipesRepository
    {
        List<Recipe> Read(string filePath);
        void Write(string filePath, List<Recipe> allRecipes);
    }

    public class RecipesRepository : IRecipesRepository
    {
        private IStringRepository _stringRepository;
        private IIngredientRegister _ingredientRegister;
        private static readonly char Separator = ',';

        public RecipesRepository(IStringRepository stringRepository, IIngredientRegister ingredientRegister)
        {
            _stringRepository = stringRepository;
            _ingredientRegister = ingredientRegister;
        }
        public List<Recipe> Read(string filePath)
        {
            List<string> recipesFromFile = _stringRepository.Read(filePath);
            List<Recipe> recipes = [];

            foreach(var recipeFromFile in recipesFromFile)
            {
                var recipe = RecipeFromString(recipeFromFile);
                recipes.Add(recipe);
            }


            return recipes;
        }

        private Recipe RecipeFromString(string recipeFromFile)
        {
            List<Ingredient> ingredients = [];
            var ingredientIds = recipeFromFile.Split(Separator);

            foreach(var textualId in ingredientIds)
            {
                var id = int.Parse(textualId);
                ingredients.Add(_ingredientRegister.GetById(id));
            }

            return new Recipe(ingredients);
        }

        public void Write(string filePath, List<Recipe> allRecipes)
        {
            List<string> recipesAsString = [];

            foreach(var recipe in allRecipes)
            {
                List<int> allIds = [];
                foreach(var ingredient in recipe.Ingredients)
                {
                    allIds.Add(ingredient.id);
                }

                recipesAsString.Add(string.Join(",", allIds));
            }

            _stringRepository.Write(filePath, recipesAsString);
        } 
    }
}