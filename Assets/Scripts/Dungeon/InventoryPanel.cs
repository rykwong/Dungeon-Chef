using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public GameObject inventory;
    private static bool inventoryOpen = false;
    void Update()
    {
        checkKey();
    }

    public void checkKey()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(inventoryOpen)
            {
                closeInventoryPanel();
            }
            else
            {
                loadInventoryPanel();
            }
        }
    }

    public void loadInventoryPanel()
    {
        inventory.GetComponent<CanvasGroup>().alpha = 1;
        Time.timeScale = 0f;
        inventoryOpen = true;
    }

    public void closeInventoryPanel()
    {
        inventory.GetComponent<CanvasGroup>().alpha = 0;
        Time.timeScale = 1f;
        inventoryOpen = false;
    }
}