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


    private float score = 0f;
    private int difficulty = 1;
    private int maxDifficulty = 10;
    private int scoreToNextLevel = 10;

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
        if (difficulty <= 5)
            scoreToNextLevel *= 2;
        else
            scoreToNextLevel *= 4;

        difficulty++;
        player.GetComponent<playerEngine>().SetSpeed(difficulty * 2);
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
