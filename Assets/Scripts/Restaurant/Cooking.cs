using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Cooking : MonoBehaviour
{
  [SerializeField] Database database = null;
  [SerializeField] Inventory inventory = null;
  [SerializeField] Furnace furnace = null;
  [SerializeField] Timer cookTimer = null;
  
  [SerializeField] Item trashFood = null;

  [SerializeField] Button cookButton = null;
  [SerializeField] Button resetButton = null;
  [SerializeField] Button trashButton = null;
  [SerializeField] Button dungeonButton = null;
  [SerializeField] Button recipeBookButton = null;

  [SerializeField] AudioSource sfxTrash = null;
  [SerializeField] AudioSource sfxCooking = null;
  [SerializeField] AudioSource sfxCookingFinished = null;

  public void Trash()
  {
    if (furnace.isEmpty()) return;

    furnace.Clear();
    sfxTrash.time = 0.1f;
    sfxTrash.Play();
  }

  public void Reset()
  {
    foreach (ItemSlot furnaceSlot in furnace.furnaceSlots)
    {
      if (furnaceSlot.Item != null)
      {
        inventory.AddItem(furnaceSlot.Item);
        furnaceSlot.Item = null;
      }
    }
  }

  public void Cook()
  {
    if (furnace.isEmpty()) return;

    Recipe recipe = FindValidRecipe();

    if (recipe != null)
    { 
      StartCoroutine(WaitToCook(recipe.Food));
    }
    else
    {
      StartCoroutine(WaitToCook(trashFood));
    }
  }

  private Recipe FindValidRecipe()
  {
    int level = PlayerPrefs.GetInt("level");

    Recipe[] unlockedRecipes = database.GetRecipesUpToLevel(level);

    foreach (Recipe recipe in unlockedRecipes)
    {
      if (recipe.CanMakeWith(furnace.GetItems()))
      {
        return recipe;
      }
    }

    return null;
  }

  private IEnumerator WaitToCook(Item food)
  {
    Disable();
    sfxCooking.Play();
    cookTimer.SetTimer(3);
    yield return new WaitForSeconds(3);
    sfxCooking.Stop();
    furnace.Clear();
    furnace.furnaceSlots[4].Item = food.Instantiate();
    sfxCookingFinished.time = 0.1f;
    sfxCookingFinished.Play();
    cookTimer.Reset();
    Enable();
  }

  private void Disable()
  {
    furnace.Disable();
    cookButton.interactable = false;
    resetButton.interactable = false;
    trashButton.interactable = false;
    dungeonButton.interactable = false;
    recipeBookButton.interactable = false;
  }

  private void Enable()
  {
    furnace.Enable();
    cookButton.interactable = true;
    resetButton.interactable = true;
    trashButton.interactable = true;
    dungeonButton.interactable = true;
    recipeBookButton.interactable = true;
  }
}