using CookiesCookbook.Recipes.Ingredients;

namespace CookiesCookbook.Recipes.RecipesUserIntraction
{
    public interface IRecipesUserIntraction
    {
        void ShowMessage(string message);
        void Exit();
        void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);   
        void PromptToCreateRecipe();    
        IEnumerable<Ingredient> ReadIngredientsFromUser(); 
    }

    public class RecipesUserInteraction : IRecipesUserIntraction
    {
        private readonly IIngredientRegister _ingredientRegister;

        public RecipesUserInteraction(IIngredientRegister ingredientRegister)
        {
            _ingredientRegister = ingredientRegister;
        }
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void Exit()
        {
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
        {
            if(allRecipes.Count() > 0)
            {
                Console.WriteLine("Exisitng Recipes are:"+Environment.NewLine);
                
                var count = 1;
                foreach(var recipe in allRecipes)
                {
                    Console.WriteLine($"***** {count} *****");
                    Console.WriteLine(recipe);
                    Console.WriteLine();
                    count++;

                }
            }
        }

        public void PromptToCreateRecipe()
        {
            foreach(var ingredient in _ingredientRegister.All)
            {
                Console.WriteLine(ingredient);
            }
        }

        public IEnumerable<Ingredient> ReadIngredientsFromUser()
        {
            bool shallStop = false;
            List<Ingredient> ingredients = [];

            while(!shallStop)
            {
                Console.WriteLine("Add an ingredient by its ID, type else to finish");
                var userInput = Console.ReadLine();

                if(int.TryParse(userInput, out int id))
                {
                    var selectedIngredinet = _ingredientRegister.GetById(id);
                    if(selectedIngredinet is not null)
                    {
                        ingredients.Add(selectedIngredinet);
                    }
                }
                else
                {
                    shallStop = true;
                }
            }

            return ingredients;
        }
    }
}