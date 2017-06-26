using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class RecipeDatabase : MonoBehaviour
{
    private static RecipeDatabase instance;

    public TextAsset recipeJson;
    private Dictionary<string, Recipe> recipes;

    private RecipeDatabase() { }

    public static RecipeDatabase Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<RecipeDatabase>() as RecipeDatabase;
            return instance;
        }
    }

    void Awake()
    {
        if (!ItemDatabase.Instance.ItemsLoaded)
            ItemDatabase.Instance.Load();
        recipes = new Dictionary<string, Recipe>();

        Recipe[] recipesFromJson = JsonConvert.DeserializeObject<Recipe[]>(recipeJson.text);
        if (recipesFromJson != null)
        {
            for (int i = 0; i < recipesFromJson.Length; i++)
                AddNewRecipe(recipesFromJson[i]);
        }
    }

    public void AddNewRecipe(Recipe newRecipe)
    {
        recipes.Add(newRecipe.RecipeName, newRecipe);
    }

    public Recipe GetRecipe(string name)
    {
        Recipe wantedRecipe = null;
        recipes.TryGetValue(name, out wantedRecipe);
        return wantedRecipe;
    }

    public Recipe MatchRecipe(List<BaseItem> inputs)
    {
        List<Recipe> possibleRecipes = new List<Recipe>();

        Recipe recipe;
        foreach (KeyValuePair<string, Recipe> entry in recipes)
        {
            recipe = entry.Value;
            bool valid = true;
            for (int i = 0; i < inputs.Count; i++)
            {
                if (!recipe.Hasingredient(inputs[i]))
                {
                    valid = false;
                    break;
                }
            }
            if (valid)
                possibleRecipes.Add(recipe);
        }

        if (possibleRecipes.Count != 0)
            return possibleRecipes[0];
        return null;
    }
}
