using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public int health;
    public float direction;
    public GameObject proj;
    public GameObject deathAudio;
    public float startTime;
    private float timeBtw;

    public int numHearts;
    public Image[] hearts;
    public Sprite full;
    public Sprite empty;
    public Sprite half;

    private float horizontal;
    private float vertical;

    void Start()
    {
        health = PlayerPrefs.GetInt("health");
    }

    void FixedUpdate()
    {
        horizontal= Input.GetAxis ("Horizontal");
        vertical = Input.GetAxis ("Vertical");

        GetComponent<Rigidbody2D> ().velocity = new Vector2 (horizontal * speed, vertical * speed);

        if(horizontal > 0)
        {
            GetComponent<Animator>().SetBool("IsMoving",true);
            GetComponent<Animator>().SetFloat("xInput",Mathf.CeilToInt(horizontal));
            GetComponent<Animator>().SetFloat("yInput",0);
            direction = 1;
        }
        else if(horizontal < 0)
        {
            GetComponent<Animator>().SetBool("IsMoving",true);
            GetComponent<Animator>().SetFloat("xInput",Mathf.FloorToInt(horizontal));
            GetComponent<Animator>().SetFloat("yInput",0);
            direction = 2;
        }
        else if(vertical > 0)
        {
            GetComponent<Animator>().SetBool("IsMoving",true);
            GetComponent<Animator>().SetFloat("xInput",0);
            GetComponent<Animator>().SetFloat("yInput",Mathf.CeilToInt(vertical));
            direction = 3;
        }
        else if(vertical < 0)
        {
            GetComponent<Animator>().SetBool("IsMoving",true);
            GetComponent<Animator>().SetFloat("xInput",0);
            GetComponent<Animator>().SetFloat("yInput",Mathf.FloorToInt(vertical));
            direction = 4;
        }
        else
        {
            GetComponent<Animator>().SetBool("IsMoving",false);
        } 
    }

    void Update()
    {
        if(timeBtw <= 0)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                Shoot();
                timeBtw = startTime;
            }  
        }
        else
        {
            timeBtw -= Time.deltaTime;
        }
        if(health <= 0)
        {
            Debug.Log("You died");
            death();
        }
        checkHearts();
    }

    private void death()
    {
        // Instantiate(deathAudio, transform.position,Quaternion.identity);
        // Destroy(gameObject,1f);
        LoadScenes.loadGameOverScene();
    }

    private void checkHearts()
    {
        int numFull = (int)health/2;
        
        for(int i = 0; i < hearts.Length; i ++)
        {
            if(i < numHearts)
            {
                hearts[i].enabled = true;
            }
            else{
                hearts[i].enabled = false;
            }

            if(i < numFull)
            {
                hearts[i].sprite = full;
            }
            else if(i * 2 >= health){
                hearts[i].sprite = empty;
            }
            else{
                hearts[i].sprite = half;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(proj, transform.position,Quaternion.identity);
    }

    public IEnumerator TakeDamage(int numLoops)
    {
        for (int i = 0; i < numLoops; i++)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.05f);
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("health", health);
    }
}