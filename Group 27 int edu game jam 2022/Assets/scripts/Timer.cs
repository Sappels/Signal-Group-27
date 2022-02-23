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

    void Update()
    {
        timerText.text = "Time left: " + (int)timer;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (!GameManager.Instance.outOfFuel)
            {
                Debug.Log("You Win!");
            }
            else
            {
                Debug.Log("You lose");
            }
        }
    }
}
