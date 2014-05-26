using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject Mob;
    public float SpawnTimer = 3.0f;
    public int SpawnCount = 5;
    public bool Continuous = false;

    private float NextSpawnTime;
    private int spawnedMobs;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Continuous)
        {
            if (Time.time >= NextSpawnTime && spawnedMobs < SpawnCount)
            {
                spawnedMobs++;
                NextSpawnTime += SpawnTimer;
                Instantiate(Mob, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
        }
        else if (spawnedMobs < SpawnCount)
            for (spawnedMobs = 0; spawnedMobs < SpawnCount; spawnedMobs++)
                Instantiate(Mob, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
