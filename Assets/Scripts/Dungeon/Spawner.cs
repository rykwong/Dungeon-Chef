using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int numEnemies;
    public float maxX,maxY,minX,minY;
    public GameObject[] enemies;

    public GameObject[] passive;
    private bool done = false;
    private float timeBtw = 1f;
    private int level;

    void Start()
    {
        minX = transform.position.x + minX;
        maxX = transform.position.x + maxX;
        minY = transform.position.y + minY;
        maxY = transform.position.y + maxY;
        level = PlayerPrefs.GetInt("level");
    }

    void Update()
    {
        if(timeBtw <= 0 && done == false)
        {
            GenerateEnemies();
            done = true;
        }
        else
        {
            timeBtw -= Time.deltaTime;
        }
    }

    public void GenerateEnemies()
    {
        numEnemies = Random.Range(0,4 + level);
        for(int i = 0; i < numEnemies; i++)
        {
            Spawn();
        }
        if(numEnemies == 0 && level > 0)
        {
            SpawnFood();
        }
        else{
            Spawn();
        }
    }

    public void Spawn()
    {
        int r = Random.Range(0,level + 1);

        if(r == 1)
        {
            SpawnFood();
        }
        else
        {
            Vector2 temp = new Vector2(transform.position.x,transform.position.y);
            Instantiate(enemies[r],temp,Quaternion.identity);
        }
    }

    public void SpawnFood()
    {
        int r = Random.Range(0,passive.Length);
        float x = Random.Range(minX,maxX);
        float y = Random.Range(minY,maxY);
        Vector2 temp = new Vector2(x,y);
        Instantiate(passive[r],temp,Quaternion.identity);
    }
}