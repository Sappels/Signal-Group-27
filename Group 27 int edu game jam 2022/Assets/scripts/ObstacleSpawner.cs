using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject fuelTank;

    public List<GameObject> obstacles;

    private float timeToSpawn;
    private float spawnTimer;

    private void Start()
    {
        timeToSpawn = Random.Range(1f, 8f);
        spawnTimer = timeToSpawn;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            int _randomObj = Random.Range(0, obstacles.Count);
            if (Random.value > 0.4f)
            {
                if (Random.value > 0.9f)
                {
                    Instantiate(fuelTank, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(obstacles[_randomObj], transform.position, Quaternion.Euler(-15,0,0));
                }
            }

            timeToSpawn = Random.Range(2f, 4f);
            spawnTimer = timeToSpawn;
        }
    }
}
