using UnityEngine;

public class Knife : MonoBehaviour
{
    public float speed;
    public float startRotation;
    private float rotation;
    private Player player;
    public GameObject throwAudio;

    void Start()
    {
        Instantiate(throwAudio,transform.position,Quaternion.identity);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if(player.direction == 1)
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
            transform.Rotate(0f,0f,-90f);
            rotation = -startRotation;
        }
        else if(player.direction == 2)
        {
            GetComponent<Rigidbody2D>().velocity = -transform.right * speed;
            transform.Rotate(0f,0f,90f);
            GetComponent<SpriteRenderer>().flipX = true;
            rotation = startRotation;
        }
        else if(player.direction == 3)
        {
            GetComponent<Rigidbody2D>().velocity = transform.up * speed;
            rotation = -startRotation;
        }
        else if(player.direction == 4)
        {
            GetComponent<Rigidbody2D>().velocity = -transform.up * speed;
            transform.Rotate(0f,0f,180f);
            GetComponent<SpriteRenderer>().flipX = true;
            rotation = startRotation;
        }
    }

    void Update()
    {
        transform.Rotate(0, 0, rotation * Time.timeScale);
    }
}