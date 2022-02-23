using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float startTimer;
    private float timer;

    public TMP_Text timerText;


    void Start()
    {
        timer = startTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = "Time left: " + (int)timer;

        timer -= Time.deltaTime;

        if (timer <= 0 && !GameManager.Instance.hasBeenHit && !GameManager.Instance.outOfFuel)
        {
            Debug.Log("You Won!");
        }
        else
        {
            Debug.Log("Better bring fuel next time, and make sure you don't get hit on the way!");
        }
    }
}
