using System.Linq;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu]
public class Database : ScriptableObject
{
	[SerializeField] Item[] items = null;
  [SerializeField] Recipe[] recipes = null;

	public Item[] GetItems()
	{
		return items;
	}

	public Item GetItemReference(string itemID)
	{
		foreach (Item item in items)
		{
			if (item.ID == itemID)
			{
				return item;
			}
		}
    
		return null;
	}

	public Item GetItemCopy(string itemID)
	{
		Item item = GetItemReference(itemID);

    if (item != null)
    {
      return item.Instantiate();
    }

    return null;
	}

	public Recipe[] GetRecipes()
	{
		return recipes;
	}

	public Recipe[] GetRecipesUpToLevel(int level)
	{
		List<Recipe> unlockedRecipes = new List<Recipe>();

		foreach (Recipe recipe in recipes)
		{
			if (recipe.Level <= level)
			{
				unlockedRecipes.Add(recipe);
			}
		}

		return unlockedRecipes.ToArray();
	}

  public Recipe GetRecipeReference(string recipeID)
  {
    foreach (Recipe recipe in recipes)
    {
      if (recipe.ID == recipeID)
      {
        return recipe;
      }
    }

    return null;
  }

  public Recipe GetRecipeCopy(string recipeID)
	{
		Recipe recipe = GetRecipeReference(recipeID);

    if (recipe != null)
    {
      return recipe.Instantiate();
    }

    return null;
	}

	#if UNITY_EDITOR
	private void OnValidate()
	{
		LoadItems();
	}

  private void OnEnable()
	{
 		EditorApplication.projectChanged -= LoadItems;
		EditorApplication.projectChanged += LoadItems;
	}

	private void OnDisable()
	{
		EditorApplication.projectChanged -= LoadItems;
	}

	private void LoadItems()
	{
		items = FindAssetsByType<Item>("Assets/Items");
    recipes = FindAssetsByType<Recipe>("Assets/Items");
    recipes = recipes.OrderBy(recipe => recipe.Level).ToArray();
	}

	public static T[] FindAssetsByType<T>(params string[] folders) where T : Object
	{
		string type = typeof(T).Name;

		string[] guids;

		if (folders == null || folders.Length == 0) 
		{
			guids = AssetDatabase.FindAssets("t:" + type);
		} 
		else 
		{
			guids = AssetDatabase.FindAssets("t:" + type, folders);
		}

		T[] assets = new T[guids.Length];

		for (int i = 0; i < guids.Length; i++)
		{
			string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
			assets[i] = AssetDatabase.LoadAssetAtPath<T>(assetPath);
		}

		return assets;
	}
	#endif
}