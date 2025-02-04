public abstract class Ingredient
{
    public abstract int id {get;}
    public abstract string name {get;}
    public virtual string PreparationInstruction() => "Add to other ingredients.";

    public override string ToString() => $"{id}. {name}";
    
}