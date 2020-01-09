using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    private RoomTemplates templates;
    private int r;
    public bool spawned;
    public float waitTime = 4f;
    private int maxRooms = 5;

    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {   
        if(spawned == false) 
        {
            if(templates.rooms.Count > maxRooms)
            {
                Instantiate(templates.closed,transform.position,transform.rotation);
            }
            else if(openingDirection == 1)
            {
                r = Random.Range(0,templates.north.Length);
                Instantiate(templates.north[r],transform.position,templates.north[r].transform.rotation);
            }   else if(openingDirection == 2)
            {
                r = Random.Range(0,templates.west.Length);
                Instantiate(templates.west[r],transform.position,templates.west[r].transform.rotation);
            }   else if(openingDirection == 3)
            {
                r = Random.Range(0,templates.east.Length);
                Instantiate(templates.east[r],transform.position,templates.east[r].transform.rotation);
            }   else if(openingDirection == 4)
            {
                r = Random.Range(0,templates.south.Length);
                Instantiate(templates.south[r],transform.position,templates.south[r].transform.rotation);
            }
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        try
        {
            if(other.CompareTag("SpawnPoint"))
            {
                if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
                {
                    Instantiate(templates.closed, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                //Debug.Log("Destroyed a room");
                spawned = true;
            }
        }
        catch
        {

        }
    }
}