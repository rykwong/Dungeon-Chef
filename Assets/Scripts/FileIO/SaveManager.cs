using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
  [SerializeField] Database database = null;

  private const string InventoryFileName = "Inventory";
  private const string FurnaceFileName = "Furnace";

  public void LoadInventory(Inventory inventory)
  {
    var data = SaveIO.loadData<List<string>>(InventoryFileName);

    if (data == null) return;

    inventory.Clear();

    for (int i = 0; i < data.Count; i++)
    {
      if (data[i] == null)
      {
        inventory.inventorySlots[i].Item = null;
      }
      else
      {
        inventory.inventorySlots[i].Item = database.GetItemCopy(data[i]);
      }
    }
  }

  public void SaveInventory(Inventory inventory)
  {
    var data = new List<string>();

    foreach (ItemSlot inventorySlot in inventory.inventorySlots)
    {
      if (inventorySlot.Item == null)
      {
        data.Add(null);
      }
      else
      {
        data.Add(inventorySlot.Item.ID);
      }
    }

    SaveIO.saveData(InventoryFileName, data);
  }

  public void LoadFurnace(Furnace furnace)
  {
    var data = SaveIO.loadData<List<string>>(FurnaceFileName);

    if (data == null) return;

    furnace.Clear();

    for (int i = 0; i < data.Count; i++)
    {
      if (data[i] == null)
      {
        furnace.furnaceSlots[i].Item = null;
      }
      else
      {
        furnace.furnaceSlots[i].Item = database.GetItemCopy(data[i]);
      }
    }
  }

  public void SaveFurnace(Furnace furnace)
  {
    var data = new List<string>();

    foreach (ItemSlot furnaceSlot in furnace.furnaceSlots)
    {
      if (furnaceSlot.Item == null)
      {
        data.Add(null);
      }
      else
      {
        data.Add(furnaceSlot.Item.ID);
      }
    }

    SaveIO.saveData(FurnaceFileName, data);
  }
}