using UnityEngine;
using UnityEngine.UI;

public class ItemDrag : MonoBehaviour
{
  [SerializeField] Inventory inventory = null;
  [SerializeField] Furnace furnace = null;
  [SerializeField] Trash trash = null;
  [SerializeField] Orders orders = null;
  [SerializeField] Image draggableItem = null;

  private ItemSlot dragItemSlot = null;

  private void Awake()
  {
    if(furnace != null && orders != null)
    {
      furnace.OnBeginDragEvent += BeginDrag;
      orders.OnBeginDragEvent += BeginDrag;
        
      furnace.OnEndDragEvent += EndDrag;
      orders.OnEndDragEvent += EndDrag;

      furnace.OnDragEvent += Drag;
      orders.OnDragEvent += Drag;

      furnace.OnDropEvent += Drop;
      orders.OnDropEvent += Drop;
    }

    if(trash != null)
    {
      trash.OnBeginDragEvent += BeginDrag;
      trash.OnEndDragEvent += EndDrag;
      trash.OnDragEvent += Drag;
      trash.OnDropEvent += Drop;
    }
    
    inventory.OnBeginDragEvent += BeginDrag;
    inventory.OnEndDragEvent += EndDrag;
    inventory.OnDragEvent += Drag;
    inventory.OnDropEvent += Drop;
  }

  private void BeginDrag(ItemSlot itemSlot)
  {
    if (itemSlot.Item != null)
    {
      dragItemSlot = itemSlot;
      draggableItem.sprite = itemSlot.Item.Sprite;
      draggableItem.transform.position = Input.mousePosition;
      draggableItem.enabled = true;
    }
  }

  private void EndDrag(ItemSlot itemSlot)
  {
    dragItemSlot = null;
    draggableItem.enabled = false;
  }

  private void Drag(ItemSlot itemSlot)
  {
    if (draggableItem.enabled)
    {
      var newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
      draggableItem.transform.position = Camera.main.ScreenToWorldPoint(newPosition);
    }
  }

  private void Drop(ItemSlot dropItemSlot)
  {
    if (dragItemSlot == null) return;

    Item draggedItem = dragItemSlot.Item;
    dragItemSlot.Item = dropItemSlot.Item;
    dropItemSlot.Item = draggedItem;
  }
}