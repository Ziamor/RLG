using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public struct RecipeIngredient
{
    public string itemID;
    public int amount;

    private BaseItem item;

    public BaseItem Item
    {
        get
        {
            if (item == null)
                item = ItemDatabase.Instance.GetItem(itemID);
            return item;
        }
        set { item = value; }
    }
}

public class Recipe
{
    private string recipeName;
    private string recipeDesc;
    private BaseItem recipeProduct;
    private string recipeProductID;
    private List<RecipeIngredient> recipeInputs;

    public string RecipeName
    {
        get { return recipeName; }
        set { recipeName = value; }
    }

    public string RecipeDesc
    {
        get { return recipeDesc; }
        set { recipeDesc = value; }
    }

    public BaseItem RecipeProduct
    {
        get
        {
            if (recipeProduct == null)
                recipeProduct = ItemDatabase.Instance.GetItem(recipeProductID);
            return recipeProduct;
        }
        set { recipeProduct = value; }
    }

    public string RecipeProductID
    {
        get { return recipeProductID; }
        set { recipeProductID = value; }
    }

    public List<RecipeIngredient> RecipeInputs
    {
        get { return recipeInputs; }
        set { recipeInputs = value; }
    }

    public bool Hasingredient(BaseItem input)
    {
        foreach (RecipeIngredient ingredient in recipeInputs)
        {
            if (ingredient.Item == input)
                return true;
        }
        return false;
    }
}

