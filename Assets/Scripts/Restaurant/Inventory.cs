using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
  [SerializeField] List<Item> startingItems = null;
  [SerializeField] Transform inventorySlotsParent = null;
  [SerializeField] SaveManager saveManager = null;
  
  public ItemSlot[] inventorySlots = null;

  public event Action<ItemSlot> OnBeginDragEvent;
  public event Action<ItemSlot> OnEndDragEvent;
  public event Action<ItemSlot> OnDragEvent;
  public event Action<ItemSlot> OnDropEvent;

  private void Start()
  {
    foreach (ItemSlot inventorySlot in inventorySlots)
    {
      inventorySlot.OnBeginDragEvent += slot => OnBeginDragEvent(slot);
      inventorySlot.OnEndDragEvent += slot => OnEndDragEvent(slot);
      inventorySlot.OnDragEvent += slot => OnDragEvent(slot);
      inventorySlot.OnDropEvent += slot => OnDropEvent(slot);
    }
    
    saveManager.LoadInventory(this);
    //SetStartingItems();
  }

  private void OnDestroy()
  {
    saveManager.SaveInventory(this);
  }

  private void OnValidate()
  {
    if (inventorySlotsParent != null)
    {
      inventorySlots = inventorySlotsParent.GetComponentsInChildren<ItemSlot>();
    }

    SetStartingItems();
  }

  private void SetStartingItems()
  {
    int i = 0;

    for (; i < startingItems.Count && i < inventorySlots.Length; i++)
    {
      inventorySlots[i].Item = startingItems[i].Instantiate();
    }

    for (; i < inventorySlots.Length; i++)
    {
      inventorySlots[i].Item = null;
    }
  }

  public bool AddItem(Item item)
  {
    foreach (ItemSlot inventorySlot in inventorySlots)
    {
      if (inventorySlot.Item == null)
      {
        inventorySlot.Item = item;
        return true;
      }
    }

    return false;
  }

  public bool RemoveItem(Item item)
  {
    foreach (ItemSlot inventorySlot in inventorySlots)
    {
      if (inventorySlot.Item == item)
      {
        inventorySlot.Item = null;
        return true;
      }
    }

    return false;
  }

  public Item RemoveItem(string itemID)
  {
    foreach (ItemSlot inventorySlot in inventorySlots)
    {
      Item item = inventorySlot.Item;

      if (item != null && item.ID == itemID)
      {
        inventorySlot.Item = null;
        return item;
      }
    }

    return null;
  }

  public bool IsFull()
  {
    foreach (ItemSlot inventorySlot in inventorySlots)
    {
      if (inventorySlot.Item == null)
      {
        return false;
      }
    }

    return true;
  }

  public void Clear()
  {
    foreach (ItemSlot inventorySlot in inventorySlots)
    {
      if (inventorySlot.Item != null && Application.isPlaying)
      {
        inventorySlot.Item.Destroy();
      }
      
      inventorySlot.Item = null;
    }
  }
}