using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RecipeSlot : MonoBehaviour, IPointerClickHandler
{
  [SerializeField] Image image = null;
  [SerializeField] Sprite unknown = null;

  public event Action<RecipeSlot> OnLeftClickEvent;

  private Color enabledColor = Color.white;

  private Recipe recipe;
  public Recipe Recipe
  {
    get
    {
      return recipe;
    }

    set
    {
      recipe = value;

      if (recipe == null)
      {
        image.sprite = unknown;
        image.color = enabledColor;
      }
      else
      {
        image.sprite = recipe.Food.Sprite;
        image.color = enabledColor;
      }
    }
  }

  private void OnValidate()
  {
    if (image == null)
    {
      image = GetComponent<Image>();
    }
  }

  public void OnPointerClick(PointerEventData eventData)
  {
    if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
    {
      if (OnLeftClickEvent != null)
      {
        OnLeftClickEvent(this);
      }
    }
  }
}