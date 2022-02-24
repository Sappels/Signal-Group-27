using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public float score;
    public int treesDestroyed = 0;

    private float finalScore;
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

    private void CalculateFinalScore()
    {
        var gmInstance = GameManager.Instance;
        if (gmInstance.gameOver)
        {
            finalScore = score;
        }
        else if (gmInstance.badEnding)
        {
            finalScore = score;
            finalScore += (1000 * treesDestroyed);
        }
        else if (gmInstance.goodEnding)
        {
            finalScore = score;
            finalScore += (1000 * treesDestroyed);

        }
    }
}
