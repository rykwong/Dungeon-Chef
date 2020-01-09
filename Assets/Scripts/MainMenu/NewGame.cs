using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
  private void OnDestroy()
  {
    if (PlayerPrefs.HasKey("saved") == false)
    {
      PlayerPrefs.SetString("saved", "true");
    }

    if (PlayerPrefs.HasKey("volume") == false)
    {
      PlayerPrefs.SetFloat("volume", 1.0f);
    }

    if (PlayerPrefs.HasKey("health") == false)
    {
      PlayerPrefs.SetInt("health", 10);
    }

    if (PlayerPrefs.HasKey("level") == false)
    {
      PlayerPrefs.SetInt("level", 0);

      // New players start with 4 Fish
      List<string> startingItems = new List<string>();
      startingItems.Add("f5fa3d6cd3562324e89cecfff09055dd");
      startingItems.Add("f5fa3d6cd3562324e89cecfff09055dd");
      startingItems.Add("f5fa3d6cd3562324e89cecfff09055dd");
      startingItems.Add("f5fa3d6cd3562324e89cecfff09055dd");
      SaveIO.saveData("Inventory", startingItems);

      List<string> emptyList = new List<string>();
      SaveIO.saveData("Furnace", emptyList);
    }

    if (PlayerPrefs.HasKey("reputation") == false)
    {
      PlayerPrefs.SetInt("reputation", 100);
    }

    if (PlayerPrefs.HasKey("correctOrders") == false)
    {
      PlayerPrefs.SetInt("correctOrders", 0);
    }

    if (PlayerPrefs.HasKey("wrongOrders") == false)
    {
      PlayerPrefs.SetInt("wrongOrders", 0);
    }
  }
}