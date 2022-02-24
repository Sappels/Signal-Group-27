using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int frameRate;

    public float gameSpeed;
    public bool hasBeenHit;
    public bool outOfFuel;

    public bool gameOver;
    public bool goodEnding;
    public bool badEnding;

    public GameObject player;
    public FiringMaLazah lazah;

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    void Start()
    {
        Application.targetFrameRate = 60;

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        lazah = player.GetComponent<FiringMaLazah>();
    }

    private void Update()
    {
        if (lazah.fuelCapacity <= 0 )
        {
            outOfFuel = true;
        }
        else
        {
            outOfFuel = false;
        }
    }

    public GameOverScreen GameOverScreen;
    int maxPlatform = 0;

    public void GameOver()
    {
        GameOverScreen.Setup(maxPlatform);
    }
}
