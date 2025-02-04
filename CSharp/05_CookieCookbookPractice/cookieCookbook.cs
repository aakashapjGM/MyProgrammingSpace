using System.Buffers;
using System.Net.Security;

namespace CookieCookbookPractice;

#region Program
public class Program
{
    public static void Main(string[] args)
    {
        CookieRecipesApp cookieRecipesApp = new(new RecipesRepository(), new RecipesUserInteraction());
        cookieRecipesApp.Run("filePath");
    }
}
#endregion

#region Cookies Recipes Application
public class CookieRecipesApp
{
    IRecipesRepository _recipesRepository;
    IRecipesUserInteraction _recipesUserInteraction;
    public CookieRecipesApp(IRecipesRepository recipesRepository, IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run(string filePath)
    {
        var allRecipes = _recipesRepository.Read(filePath);

        _recipesUserInteraction.PrintintExistingRecipes(allRecipes);
    }
}

#endregion

#region Recipes User Interaction

public interface IRecipesUserInteraction
{
    public void ShowMessage(string message);
    public void PrintintExistingRecipes(IEnumerable<Recipe> allRecipes);
    public void PromptToCreateRecipes();
    public void Exit();
}

public class RecipesUserInteraction : IRecipesUserInteraction
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void PrintintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if(allRecipes.Count()>0)
        {
            int Count = 1;
            foreach(var recipe in allRecipes)
            {
                Console.WriteLine($"***** {Count} *****");
                Console.WriteLine(recipe);
                Console.WriteLine();
                Count++;
            }
        }

        
    }

    public void PromptToCreateRecipes()
    {

    }

    public void Exit()
    {
        Console.WriteLine("Press any key to Exit");
        Console.ReadKey();
    }
}
#endregion

#region Recipes Repository

public interface IRecipesRepository
{
    public IEnumerable<Recipe> Read(string filePath);
    public void Write(string filePath, IEnumerable<Recipe> newRecipe);
}
public class RecipesRepository : IRecipesRepository
{
    public IEnumerable<Recipe> Read(string filePath)
    {
        return new List<Recipe>
        {
            new Recipe(new List<Ingredient>{
                new WheatFlour(),
                new Butter(),
                new Sugar()
            }),

            new Recipe(new List<Ingredient>{
                new CoconutFlour(),
                new CocoaPowder(),
                new Cinnamon()
            })
        };
    }

    public void Write(string filePath, IEnumerable<Recipe> newRecipe)
    {

    }
}

#endregion

#region Recipe Class
public class Recipe
{
    public IEnumerable<Ingredient> Ingredients;
    public Recipe(IEnumerable<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }
    public override string ToString()
    {
        List<string> steps = [];
        foreach(var ingredient in Ingredients)
        {
            steps.Add($"{ingredient.name} -> {ingredient.PreparationInstruction()}");
        }
        return string.Join(Environment.NewLine, steps);
    }
}

#endregion

#region Ingredients
public abstract class Ingredient
{
    public abstract int id{get;}
    public abstract string name {get;}
    public virtual string PreparationInstruction() => "Add to other ingredients";
}

public abstract class Flour : Ingredient
{
    public override string PreparationInstruction() => $"Sieve. {base.PreparationInstruction()}";
}

public abstract class Spice : Ingredient
{
    public override string PreparationInstruction() => $"Take half a teaspoon. {base.PreparationInstruction()}";
}

public class WheatFlour : Flour
{
    public override int id => 1;
    public override string name => "Wheat Flour";
}


public class CoconutFlour : Flour
{
    public override int id => 2;
    public override string name => "Coconut Flour";
}

public class Butter : Ingredient
{
    public override int id => 3;
    public override string name => "Butter";
    public override string PreparationInstruction() => $"Melt on low heat. {base.PreparationInstruction()}";
}

public class Chocolate : Ingredient
{
    public override int id => 4;
    public override string name => "Chocolate";
    public override string PreparationInstruction() => $"Melt in a water bath. {base.PreparationInstruction()}";
}

public class Sugar : Ingredient
{
    public override int id => 5;
    public override string name => "Suger";
    public override string PreparationInstruction() => base.PreparationInstruction();
}

public class Cardamom : Spice
{
    public override int id => 6;
    public override string name => "Cardamom";
}

public class Cinnamon : Spice
{
    public override int id => 7;
    public override string name => "Cinnamon";
    
}

public class CocoaPowder : Ingredient
{
    public override int id => 8;
    public override string name => "Cocoa Powder";
    public override string PreparationInstruction() => base.PreparationInstruction();
}

#endregion

#region Ingredient Register

public interface IIngredientRegister
{
    public IEnumerable<Ingredient> All {get;}
    public Ingredient GetById(int Id);
}

public class IngredientRegister : IIngredientRegister
{
    public IEnumerable<Ingredient> All => new List<Ingredient>
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

    public Ingredient GetById(int Id)
    {
        foreach(var ingredient in All)
        {
            if(ingredient.id == Id)
            {
                return ingredient;
            }
        }
        return null;
    }
}

#endregion