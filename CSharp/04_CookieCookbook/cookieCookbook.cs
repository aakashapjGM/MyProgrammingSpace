using System.Diagnostics;

using CookiesCookbook.Recipes;
using CookiesCookbook.Recipes.Ingredients;
using CookiesCookbook.Recipes.RecipesRepository;
using CookiesCookbook.Recipes.RecipesUserIntraction;
using CookiesCookbook.Recipes.StringRepository;
using CookiesCookbook.Recipes.FileMetaData;

namespace CookiesCookbook;


public class Program
{
    public static void Main(string[] args)
    {
        FileFormat Format = FileFormat.Json;
        IStringRepository stringRepository = Format == FileFormat.Json ? new StringJsonRepository() : new StringTextualRepository();

        var ingredientRegister =  new IngredientRegister() ;
        
        var cookiesRecipesApp = new CookiesRecipesApp(new RecipesRepository(stringRepository, ingredientRegister) , new RecipesUserInteraction(ingredientRegister) );
        
        const string FileName = "Recipes";
        string filePath = Format == FileFormat.Json ? $"{FileName}.json" : $"{FileName}.txt";
        
        cookiesRecipesApp.Run(filePath);
    }
}



public class CookiesRecipesApp
{
    private readonly RecipesRepository _recipesRepository;
    private readonly RecipesUserInteraction _recipesUserInteraction;

    public CookiesRecipesApp(RecipesRepository recipesRepository, RecipesUserInteraction recipiesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipiesUserInteraction;
    }
    public void Run(string filePath)
    {

        var allRecipes = _recipesRepository.Read(filePath);

        _recipesUserInteraction.PrintExistingRecipes(allRecipes);
        _recipesUserInteraction.PromptToCreateRecipe();

        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        if(ingredients.Count() > 0)
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);

            _recipesRepository.Write(filePath, allRecipes);

            _recipesUserInteraction.ShowMessage("Recipe added:");
            _recipesUserInteraction.ShowMessage(recipe.ToString());
        }
        else
        {
            _recipesUserInteraction.ShowMessage("No ingredients have been selected." + "Recipe will not be saved."); 
        }

        _recipesUserInteraction.Exit();
    }
}







