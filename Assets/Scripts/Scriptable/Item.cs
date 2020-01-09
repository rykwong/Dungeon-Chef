using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu]
public class Item : ScriptableObject, IEquatable<Item>
{
  [SerializeField] string id;
  public string ID { get { return id; } }
  public string Name;
  public Sprite Sprite;

  #if UNITY_EDITOR
  private void OnValidate()
  {
    string path = AssetDatabase.GetAssetPath(this);
    id = AssetDatabase.AssetPathToGUID(path);
  }
  #endif

  public Item Instantiate()
  {
    return Instantiate(this);
  }

  public void Destroy()
  {
    Destroy(this);
  }

  public bool Equals(Item other)
  {
    return this.ID == other.ID;
  }
}