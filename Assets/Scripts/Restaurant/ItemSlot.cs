using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
  [SerializeField] Image image;

  public event Action<ItemSlot> OnBeginDragEvent;
  public event Action<ItemSlot> OnEndDragEvent;
  public event Action<ItemSlot> OnDragEvent;
  public event Action<ItemSlot> OnDropEvent;

  private Color enabledColor = Color.white;
  private Color disabledColor = Color.clear;
  private Color draggedColor = Color.clear;

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

  public void OnBeginDrag(PointerEventData eventData)
  {
    if (Item != null)
    {
      image.color = draggedColor;
    }

    if (OnBeginDragEvent != null)
    {
      OnBeginDragEvent(this);
    }
  }

  public void OnEndDrag(PointerEventData eventData)
  {
    if (Item != null)
    {
      image.color = enabledColor;
    }

    if (OnEndDragEvent != null)
    {
      OnEndDragEvent(this);
    }
  }

  public void OnDrag(PointerEventData eventData)
  {
    if (OnDragEvent != null)
    {
      OnDragEvent(this);
    }
  }

  public void OnDrop(PointerEventData eventData)
  {
    if (OnDropEvent != null)
    {
      OnDropEvent(this);
    }
  }

  public void Enable()
  {
    this.enabled = true;
    
    if (Item != null)
    {
      image.color = enabledColor;
    }
  }

  public void Disable()
  {
    this.enabled = false;

    if (Item != null)
    {
      this.image.color = Color.gray;
    }
  }
}