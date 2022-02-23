using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public float score;


    private float timer = 3;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        scoreText.text = "Score: " + (int)score;
        if (timer <= 0)
        {
            score += ((Time.deltaTime * 10) * GameManager.Instance.gameSpeed);
        }
    }
}
