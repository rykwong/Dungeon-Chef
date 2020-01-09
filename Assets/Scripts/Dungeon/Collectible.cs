using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Item drop;
    public Inventory inventory;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(inventory.AddItem(drop.Instantiate()))
            {
                Destroy(gameObject);
            }
        }
    }
}