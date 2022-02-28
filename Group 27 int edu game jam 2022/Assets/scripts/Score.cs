using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;
    public TMP_Text treesdesText;

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
        if (timer <= 0 && !GameManager.Instance.reachedTop)
        {
            score += ((Time.deltaTime * 10) * GameManager.Instance.gameSpeed);
        }

        if (GameManager.Instance.reachedTop)
        {
            scoreText.gameObject.SetActive(false);
            finalScoreText.gameObject.SetActive(true);
            treesdesText.gameObject.SetActive(true);
            finalScoreText.text = "Your final score is: " + (int)PlayerPrefs.GetFloat("finalScore");
        }

        CalculateFinalScore();
    }

    private void CalculateFinalScore()
    {
        if (GameManager.Instance.gameOver || GameManager.Instance.reachedTop)
        {
            finalScore = score;
            finalScore += (500 * treesDestroyed);
            PlayerPrefs.SetFloat("finalScore", finalScore);
            PlayerPrefs.SetInt("treesDestroyed", treesDestroyed);

        }
    }
}
