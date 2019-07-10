using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuController : MonoBehaviour
{
    public Text highScoreText;

    public GameObject loadingScreen;
    public Slider slider;

    private void Start()
    {

        highScoreText.text = "Highscore : " + ((int)PlayerPrefs.GetFloat("highScore")).ToString();

    }

    public void ToGame()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Game");

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
