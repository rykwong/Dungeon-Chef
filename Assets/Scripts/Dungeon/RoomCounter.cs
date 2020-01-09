using UnityEngine;

public class RoomCounter : MonoBehaviour
{
    public int count;

    void Update()
    {
        count = GameObject.FindGameObjectsWithTag("Room").Length;
    }
}