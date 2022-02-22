using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public float score;


    private float timer = 5;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        scoreText.text = "Score: " + (int)score;
        if (timer <= 3)
        {
            score += ((Time.deltaTime * 10) * GameManager.Instance.gameSpeed);
        }
    }
}
