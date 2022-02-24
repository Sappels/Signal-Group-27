using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    
    public float startTimer;
    private float timer;

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
                GameManager.Instance.goodEnding = true;
                GameManager.Instance.badEnding = false;
                //Load win cutscene
            }
            else
            {
                Debug.Log("You lose");
                GameManager.Instance.goodEnding = false;
                GameManager.Instance.badEnding = true;
                //Load lose cutscene
            }
        }
    }
}
