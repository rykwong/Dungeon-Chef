using UnityEngine;

public class Ingredients : MonoBehaviour
{
  [SerializeField] Transform ingredientSlotsParent = null;
  [SerializeField] IngredientSlot[] ingredientSlots = null;

  private void OnValidate()
  {
    if (ingredientSlotsParent != null)
    {
      ingredientSlots = ingredientSlotsParent.GetComponentsInChildren<IngredientSlot>();
    }
  }

  public void AddIngredients(Item[] ingredients)
  {
    int i = 0;

    for (; i < ingredients.Length; i++)
    {
      ingredientSlots[i].Item = ingredients[i];
    }

    for (; i < ingredientSlots.Length; i++)
    {
      ingredientSlots[i].Item = null;
    }
  }
}