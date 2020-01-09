using UnityEngine;

public class Exit : MonoBehaviour
{
    private GameObject[] enemies;
    public GameObject exitAudio;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            exitDungeon();
        }
        else if(!other.CompareTag("Projectile")){
            //Debug.Log(other.tag);
            Destroy(other.gameObject);
        }
    }

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < enemies.Length; i ++)
        {
            if(enemies[i].transform.position.x < transform.position.x + 4.5f && enemies[i].transform.position.x > transform.position.x - 4.5f && enemies[i].transform.position.y < transform.position.y + 2.5f && enemies[i].transform.position.y > transform.position.y - 2.5f)
            {
                Destroy(enemies[i].gameObject);
            }
        }
    }
    
    public void exitDungeon()
    {
        Instantiate(exitAudio, transform.position, Quaternion.identity);
        GameObject.FindGameObjectWithTag("Manager").GetComponent<SceneTransitions>().LoadTransition("Transition");
    }
}