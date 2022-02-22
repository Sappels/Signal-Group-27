using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject rock;
    public GameObject fuelTank;

    private float timeToSpawn;
    private float spawnTimer;
    private int diceRoll = 0;

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
            diceRoll = Random.Range(1, 4);
            if (diceRoll == 1 || diceRoll == 2)
            {
                if (Random.value > 0.9f)
                {
                    Instantiate(fuelTank, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(rock, transform.position, Quaternion.identity);
                }
            }
            diceRoll = 0;

            timeToSpawn = Random.Range(3f, 5f);
            spawnTimer = timeToSpawn;
        }
    }
}
