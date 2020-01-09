using System;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
  [SerializeField] Database database = null;
  [SerializeField] Transform recipeSlotsParent = null;
  
  public RecipeSlot[] recipeSlots = null;

  public event Action<RecipeSlot> OnLeftClickEvent;

  private void Start()
  {
    foreach (RecipeSlot recipeSlot in recipeSlots)
    {
      recipeSlot.OnLeftClickEvent += slot => OnLeftClickEvent(slot);
    }

    SetUnlockedRecipes();
  }

  private void OnValidate()
  {
    if (recipeSlotsParent != null)
    {
      recipeSlots = recipeSlotsParent.GetComponentsInChildren<RecipeSlot>();
    }

    SetUnlockedRecipes();
  }

  private void SetUnlockedRecipes()
  {
    int level = PlayerPrefs.GetInt("level");

    Recipe[] unlockedRecipes = database.GetRecipesUpToLevel(level);

    int i = 0;

    for (; i < unlockedRecipes.Length; i++)
    {
      recipeSlots[i].Recipe = unlockedRecipes[i];
    }

    for (; i < recipeSlots.Length; i++)
    {
      recipeSlots[i].Recipe = null;
    }
  }
}