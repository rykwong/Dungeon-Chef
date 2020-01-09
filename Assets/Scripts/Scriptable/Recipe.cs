using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu]
public class Recipe : ScriptableObject
{
  [SerializeField] string id;
  public string ID { get { return id; } }
  public string Name;
  public int Level;
  public int Reputation;
  public Item Food;
  public Item[] Ingredients = new Item[9];

  #if UNITY_EDITOR
  private void OnValidate()
  {
    string path = AssetDatabase.GetAssetPath(this);
    id = AssetDatabase.AssetPathToGUID(path);
  }
  #endif

  public Recipe Instantiate()
  {
    return Instantiate(this);
  }

  public void Destroy()
  {
    Destroy(this);
  }

  public bool CanMakeWith(Item[] items)
  {
    for (int i = 0; i < Ingredients.Length && i < items.Length; i++)
    {
      Item ingredient = Ingredients[i];
      Item item = items[i];

      if (ingredient == null && item != null)
      {
        return false;
      }

      if (ingredient != null && item == null)
      {
        return false;
      }

      if (ingredient != null && item != null)
      {
        if (!ingredient.Equals(item))
        {
          return false;
        }
      }
    }

    return true;
  }
}