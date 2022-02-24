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
        if (timer <= 5)
        {
            GameManager.Instance.noMoreSpawns = true;
        }
        if (timer <= 0)
        {
            timerText.gameObject.SetActive(false);
        }
    }
}
