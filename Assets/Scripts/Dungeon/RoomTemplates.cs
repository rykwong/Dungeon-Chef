using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] north;
    public GameObject[] west;
    public GameObject[] east;
    public GameObject[] south;
    public GameObject closed;
    public List<GameObject> rooms;
    public float waitTime;
    private bool exitSpawned = false;
    public GameObject exit;

    void Update()
    {
        if (waitTime <= 0 && exitSpawned == false)
        {
            Instantiate(exit, rooms[rooms.Count-1].transform.position, Quaternion.identity);
            exitSpawned = true;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}