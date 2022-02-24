using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject fuelTank;

    public List<GameObject> obstacles;

    private float timeToSpawn;
    private float spawnTimer;

    private Vector3 yRotation;

    private void Start()
    {
        yRotation.y = Random.Range(-100, 100);
        timeToSpawn = Random.Range(1f, 8f);
        spawnTimer = timeToSpawn;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (!GameManager.Instance.noMoreSpawns)
        {
            if (spawnTimer <= 0)
            {
                int _randomObj = Random.Range(0, obstacles.Count);
                if (Random.value > 0.4f)
                {
                    if (Random.value > 0.9f)
                    {
                        Debug.Log("fueltime!");
                        Instantiate(fuelTank, transform.position, Quaternion.Euler(-15, 0, 0));
                    }
                    else
                    {
                        Instantiate(obstacles[_randomObj], transform.position, Quaternion.Euler(-15, 0, 0));
                    }
                }

                timeToSpawn = Random.Range(2f, 4f);
                spawnTimer = timeToSpawn;
            }
        }
    }
}
