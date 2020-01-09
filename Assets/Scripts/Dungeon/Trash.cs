using System;
using UnityEngine;

public class Trash : MonoBehaviour
{
  [SerializeField] AudioSource sfxTrash = null;

  [SerializeField] Transform trashSlotsParent = null;

  public ItemSlot[] trashSlots = null;

  public event Action<ItemSlot> OnBeginDragEvent;
  public event Action<ItemSlot> OnEndDragEvent;
  public event Action<ItemSlot> OnDragEvent;
  public event Action<ItemSlot> OnDropEvent;

  private void Start()
  {
    foreach (ItemSlot trashSlot in trashSlots)
    {
      trashSlot.OnBeginDragEvent += slot => OnBeginDragEvent(slot);
      trashSlot.OnEndDragEvent += slot => OnEndDragEvent(slot);
      trashSlot.OnDragEvent += slot => OnDragEvent(slot);
      trashSlot.OnDropEvent += slot => OnDropEvent(slot);
    }
  }

  private void Update()
  {
    foreach (ItemSlot trashSlot in trashSlots)
    {
      if (trashSlot.Item != null && Application.isPlaying)
      {
        trashSlot.Item.Destroy();
        sfxTrash.time = 0.1f;
        sfxTrash.Play();
      }

      trashSlot.Item = null;
    }
  }

  private void OnValidate()
  {
    if (trashSlotsParent != null)
    {
      trashSlots = trashSlotsParent.GetComponentsInChildren<ItemSlot>();
    }
  }
}