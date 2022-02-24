using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TMP_Text finalScore;


    private void Start()
    {
        finalScore.text = "Your final score was: " + (int)PlayerPrefs.GetFloat("finalScore");
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");           
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Viktor");
    }
}
