using UnityEngine;

public class Door : MonoBehaviour
{
    public int openingDirection;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(openingDirection == 1)
            {
                other.GetComponent<Player>().transform.position = new Vector2(transform.position.x,transform.position.y-1);
                GameObject.Find("Main Camera").transform.position = new Vector3(GameObject.Find("Main Camera").transform.position.x,GameObject.Find("Main Camera").transform.position.y - 12,-12);
            }   else if(openingDirection == 2)
            {
                other.GetComponent<Player>().transform.position = new Vector2(transform.position.x + 1,transform.position.y);
                GameObject.Find("Main Camera").transform.position = new Vector3(GameObject.Find("Main Camera").transform.position.x + 16,GameObject.Find("Main Camera").transform.position.y,-12);
            }   else if(openingDirection == 3)
            {
                other.GetComponent<Player>().transform.position = new Vector2(transform.position.x - 1,transform.position.y);
                GameObject.Find("Main Camera").transform.position = new Vector3(GameObject.Find("Main Camera").transform.position.x - 16,GameObject.Find("Main Camera").transform.position.y,-12);
            }   else if(openingDirection == 4)
            {
                other.GetComponent<Player>().transform.position = new Vector2(transform.position.x,transform.position.y + 1);
                GameObject.Find("Main Camera").transform.position = new Vector3(GameObject.Find("Main Camera").transform.position.x,GameObject.Find("Main Camera").transform.position.y + 12,-12);
            }
        }

        if(other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
        }
    }
}