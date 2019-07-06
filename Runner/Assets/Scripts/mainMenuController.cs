using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuController : MonoBehaviour
{
    public Text highScoreText;

    private void Start()
    {

        highScoreText.text = "Highscore : " + ((int)PlayerPrefs.GetFloat("highScore")).ToString();

    }

    public void ToGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
