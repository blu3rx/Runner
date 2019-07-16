using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{

    private static gameController instance;

    private GameObject player;
    public GameObject DeathMenu;

    public Text scoreText;
    public Text endScoreText;
    public Text levelText;
    public Text fpsCounter;


    private float score = 0f;
    private int difficulty = 1;
    private int maxDifficulty = 10;
    private int scoreToNextLevel = 10;
    public int avgFrameRate;

    private bool gameOver = false;

    public void Awake()
    {
        if (instance != null)
            Destroy(gameObject);

        player = GameObject.FindGameObjectWithTag("Player");

        Application.targetFrameRate = 60;


    }

    private void Update()
    {
        score += Time.deltaTime * difficulty;
        scoreText.text = ((int)score).ToString();

        levelText.text = ("Level : " + (int)difficulty).ToString();

        if (score >= scoreToNextLevel)
            LevelUp();

        if (gameOver)
        {
            Time.timeScale = 0f;
            DeathMenu.SetActive(true);
            if (score > PlayerPrefs.GetFloat("highScore"))
                PlayerPrefs.SetFloat("highScore", score);

            endScoreText.text = ((int)score).ToString();

        }

        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        fpsCounter.text = avgFrameRate.ToString() + " FPS";

    }

    public void Restart()
    {
        gameOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }



    void LevelUp()
    {
        if (difficulty == maxDifficulty)
            return;

        difficulty++;

        if (difficulty <= 2)
        {
            scoreToNextLevel *= 2;
            player.GetComponent<playerEngine>().SetSpeed(difficulty * 3);
        }
        else if(difficulty<=4)
        {
            scoreToNextLevel *= 3;
            player.GetComponent<playerEngine>().SetSpeed(difficulty * 4);
        }
        else if (difficulty < 6)
        {
            scoreToNextLevel *= 4;
            player.GetComponent<playerEngine>().SetSpeed(difficulty * 5);
        }
        else if (difficulty <= 8)
        {
            scoreToNextLevel *= 5;
            player.GetComponent<playerEngine>().SetSpeed(difficulty * 6);
        }
       
    }

    public static gameController Instance
    {

        get
        {
            instance = FindObjectOfType<gameController>();

            if (instance == null)
            {
                GameObject go = new GameObject();
                go.name = "GameController";
                instance = go.AddComponent<gameController>();
            }
            return instance;
        }
    }

    public GameObject Player
    {
        get
        {
            return player;
        }
    }

    public bool GameOver
    {
        set
        {
            gameOver = value;
        }
    }
}
