using UnityEngine;
using System.Collections;

public class StationaryEnemy : MonoBehaviour
{
    public int health;
    public GameObject[] drops;
    public int damage;
    public GameObject hitEffect;
    public GameObject deathAudio;

    void Update()
    {
        if(health <= 0)
        {
            EnemyDrop();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("Hit player");
            other.GetComponent<Player>().health -= damage;
            //Debug.Log("Player health: " + other.GetComponent<Player>().health);
        }
        if(other.CompareTag("Projectile"))
        {
            StartCoroutine(FlashRed(2));
            Instantiate(hitEffect,transform.position,Quaternion.identity);
            Destroy(other.gameObject);
            health--;
        }
    }

    public void EnemyDrop()
    {
        int r = Random.Range(0,drops.Length);
        Instantiate(drops[r],transform.position,Quaternion.identity);
        Instantiate(deathAudio,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
    IEnumerator FlashRed(int numLoops)
    {
        for (int i = 0; i < numLoops; i++)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.05f);
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.05f);
        }
    }
}