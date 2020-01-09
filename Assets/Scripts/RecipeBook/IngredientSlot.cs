using UnityEngine;
using UnityEngine.UI;

public class IngredientSlot : MonoBehaviour
{
  [SerializeField] Image image;

  private Color normalColor = Color.white;
  private Color disabledColor = Color.clear;

  private Item item;
  public Item Item 
  {
    get 
    { 
      return item;
    }
    
    set 
    { 
      item = value;

      if (item == null)
      {
        image.sprite = null;
        image.color = disabledColor;
      } 
      else 
      {
        image.sprite = item.Sprite;
        image.color = normalColor;
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
}