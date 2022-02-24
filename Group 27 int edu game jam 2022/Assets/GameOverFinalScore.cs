using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverFinalScore : MonoBehaviour
{
    public TMP_Text finalScore;

    void Start()
    {
        finalScore.text = "Your final score was: " + (int)PlayerPrefs.GetFloat("finalScore");
    }
}
