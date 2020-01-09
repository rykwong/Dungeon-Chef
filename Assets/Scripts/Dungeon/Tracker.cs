using UnityEngine;

public class Tracker : MonoBehaviour
{
    private Transform exitTransform;
    private Transform playerTransform;

    void Update()
    {
        checkRelative();
    }

    private void checkRelative()
    {
        try 
        {
            exitTransform = GameObject.FindGameObjectWithTag("Exit").GetComponent<Transform>();
            playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            var dir = exitTransform.position - playerTransform.position;
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
        }
        catch
        {
            
        }
    }
}