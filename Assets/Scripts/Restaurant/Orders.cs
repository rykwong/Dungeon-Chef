using System;
using UnityEngine;

public class Orders : MonoBehaviour
{
  [SerializeField] OrderSlot[] orderSlots = null;

  public event Action<ItemSlot> OnBeginDragEvent;
  public event Action<ItemSlot> OnEndDragEvent;
  public event Action<ItemSlot> OnDragEvent;
  public event Action<ItemSlot> OnDropEvent;

  private void Start()
  {
    foreach (OrderSlot orderSlot in orderSlots)
    {
      orderSlot.itemSlot.OnBeginDragEvent += slot => OnBeginDragEvent(slot);
      orderSlot.itemSlot.OnEndDragEvent += slot => OnEndDragEvent(slot);
      orderSlot.itemSlot.OnDragEvent += slot => OnDragEvent(slot);
      orderSlot.itemSlot.OnDropEvent += slot => OnDropEvent(slot);
    }
  }

  private void OnValidate()
  {
    orderSlots = GetComponentsInChildren<OrderSlot>();
  }
}