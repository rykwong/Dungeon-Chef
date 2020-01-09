using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private float timer = 0.0f;
    private float waitingTime;
    private float targetPosX;
    private float targetPosY;
    public GameObject[] drops;
    public int damage;
    public GameObject hitEffect;
    public GameObject deathAudio;
    public int maxDrops;
    public int dropLevel;

    void Start()
    {
        minX = transform.position.x + minX;
        maxX = transform.position.x + maxX;
        minY = transform.position.y + minY;
        maxY = transform.position.y + maxY;
        waitingTime = Random.Range(1.0f,3.0f);
    }

    void Update()
    {
        Move();

        if(health <= 0)
        {
            EnemyDrop();
        }
    }

    public void Move()
    {
        timer += Time.deltaTime;

        if(timer > waitingTime)
        {
            timer = 0f;
            int r = Random.Range(0,4);
            if(r == 0 && transform.position.y < maxY)
            {
                targetPosX = transform.position.x;
                targetPosY = transform.position.y + 1;
                GetComponent<Animator>().SetFloat("xInput",0);
                GetComponent<Animator>().SetFloat("yInput",1);
            }
            else if(r == 1 && transform.position.y > minY)
            {
                targetPosX = transform.position.x;
                targetPosY = transform.position.y - 1;
                GetComponent<Animator>().SetFloat("xInput",0);
                GetComponent<Animator>().SetFloat("yInput",-1);
            }
            else if(r == 2 && transform.position.x < maxX)
            {
                targetPosX = transform.position.x + 1;
                targetPosY = transform.position.y;
                GetComponent<Animator>().SetFloat("yInput",0);
                GetComponent<Animator>().SetFloat("xInput",1);
            }
            else if(r == 3 && transform.position.x > minX)
            {
                targetPosX = transform.position.x - 1;
                targetPosY = transform.position.y;
                GetComponent<Animator>().SetFloat("yInput",0);
                GetComponent<Animator>().SetFloat("xInput",-1);
            }
            transform.position= new Vector2(targetPosX,targetPosY);

            GetComponent<Animator>().SetBool("IsMoving",true);
        }   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("Hit player");
            other.GetComponent<Player>().health -= damage;
            other.GetComponent<Player>().StartCoroutine(other.GetComponent<Player>().TakeDamage(2));
            //Debug.Log("Player health: " + other.GetComponent<Player>().health);
        }
        if(other.CompareTag("Projectile"))
        {
            Instantiate(hitEffect,transform.position,Quaternion.identity);
            StartCoroutine(FlashRed(2));
            Destroy(other.gameObject);
            health--;
        }
    }

    public void EnemyDrop()
    {
        int r = Random.Range(0,drops.Length);
        int dropAmount = Random.Range(1,maxDrops + 1);
        //Debug.Log(dropAmount);
        if(PlayerPrefs.GetInt("level") > dropLevel)
        {
            for(int i = 0; i < dropAmount; i ++)
            {
                Instantiate(drops[r],transform.position,Quaternion.identity);
            }
        }
        else{
            Instantiate(drops[r],transform.position,Quaternion.identity);
        }
        
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