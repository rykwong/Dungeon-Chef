using UnityEngine;

public class AddRoom : MonoBehaviour
{
    void Start()
    {
        GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>().rooms.Add(this.gameObject);
    }
}