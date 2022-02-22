using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject rock;

    private float timeToSpawn;
    private float spawnTimer;
    private int diceRoll = 0;

    private void Start()
    {
        timeToSpawn = Random.Range(4, 6);
        spawnTimer = timeToSpawn;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            diceRoll = Random.Range(1, 4);
            if (diceRoll == 1 || diceRoll == 2)
            {
                Instantiate(rock, transform.position, Quaternion.identity);
            }
            diceRoll = 0;

            timeToSpawn = Random.Range(4, 6);
            spawnTimer = timeToSpawn;
        }
    }
}
