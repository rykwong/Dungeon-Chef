using System;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour
{
  [SerializeField] Transform furnaceSlotsParent = null;
  [SerializeField] SaveManager saveManager = null;

  public ItemSlot[] furnaceSlots = null;

  public event Action<ItemSlot> OnBeginDragEvent;
  public event Action<ItemSlot> OnEndDragEvent;
  public event Action<ItemSlot> OnDragEvent;
  public event Action<ItemSlot> OnDropEvent;

  private void Start()
  {
    foreach (ItemSlot furnaceSlot in furnaceSlots)
    {
      furnaceSlot.OnBeginDragEvent += slot => OnBeginDragEvent(slot);
      furnaceSlot.OnEndDragEvent += slot => OnEndDragEvent(slot);
      furnaceSlot.OnDragEvent += slot => OnDragEvent(slot);
      furnaceSlot.OnDropEvent += slot => OnDropEvent(slot);
    }

    saveManager.LoadFurnace(this);
  }

  private void OnDestroy()
  {
    saveManager.SaveFurnace(this);
  }

  private void OnValidate()
  {
    if (furnaceSlotsParent != null)
    {
      furnaceSlots = furnaceSlotsParent.GetComponentsInChildren<ItemSlot>();
    }
  }

  public bool isEmpty()
  {
    foreach (ItemSlot furnaceSlot in furnaceSlots)
    {
      if (furnaceSlot.Item != null)
      {
        return false;
      }
    }

    return true;
  }

  public void Clear()
  {
    foreach (ItemSlot furnaceSlot in furnaceSlots)
    {
      if (furnaceSlot.Item != null && Application.isPlaying)
      {
        furnaceSlot.Item.Destroy();
      }

      furnaceSlot.Item = null;
    }
  }

  public void Enable()
  {
    foreach (ItemSlot furnaceSlot in furnaceSlots)
    {
      furnaceSlot.Enable();
    }
  }

  public void Disable()
  {
    foreach (ItemSlot furnaceSlot in furnaceSlots)
    {
      furnaceSlot.Disable();
    }
  }

  public Item[] GetItems()
  {
    List<Item> items = new List<Item>();

    foreach (ItemSlot furnaceSlot in furnaceSlots)
    {
      items.Add(furnaceSlot.Item);
    }

    return items.ToArray();
  }
}