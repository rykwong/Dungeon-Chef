using UnityEngine;
using UnityEngine.UI;

public class RecipeClick : MonoBehaviour
{
  [SerializeField] RecipeBook recipeBook = null;
  [SerializeField] Ingredients ingredients = null;
  [SerializeField] Image selectedRecipe = null;

  private Color normalColor = Color.white;
  private Color disabledColor = Color.clear;

  private void Awake()
  {
    recipeBook.OnLeftClickEvent += LeftClick;
  }

  private void LeftClick(RecipeSlot recipeSlot)
  {
    if (recipeSlot.Recipe != null)
    {
      ingredients.AddIngredients(recipeSlot.Recipe.Ingredients);
      selectedRecipe.sprite = recipeSlot.Recipe.Food.Sprite;
      selectedRecipe.color = normalColor;
    }
    else
    {
      ingredients.AddIngredients(new Item[0]);
      selectedRecipe.color = disabledColor;
    }
  }
}