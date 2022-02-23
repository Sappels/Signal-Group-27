using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float startTimer;
    private float timer;

    public TMP_Text timerText;
    public TMP_Text fuelLeftText;


    void Start()
    {
        timer = startTimer;
    }

    void Update()
    {
        timerText.text = "Time left: " + (int)timer;
        fuelLeftText.text = "Fuel: " + GameManager.Instance.lazah.fuelCapacity.ToString("F2");

        timer -= Time.deltaTime;

        if (timer <= 0 && !GameManager.Instance.hasBeenHit && !GameManager.Instance.outOfFuel)
        {
            //Still need win screen/cutscene to switch to here.
            Debug.Log("You Won!");
        }
        else
        {
            //Lose screen. (or if time allows, a cutscene where he fails to light the bonfire)
            Debug.Log("Better bring fuel next time, and make sure you don't get hit on the way!");
        }
    }
}
