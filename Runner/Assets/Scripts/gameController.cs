using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{

    private static gameController instance;

    private GameObject player;

    public Text scoreText;

    private float score = 0f;
    private int difficulty = 1;
    private int maxDifficulty = 10;
    private int scoreToNextLevel = 5;

    public void Awake()
    {
        if (instance != null)
            Destroy(gameObject);

        player = GameObject.FindGameObjectWithTag("Player");

    }
   
    private void Update()
    {
        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();

        if (score >= scoreToNextLevel)

            LevelUp();
    }

    void LevelUp()
    {
        if (difficulty == maxDifficulty)
            return;

        scoreToNextLevel *= 2;
        difficulty++;
        player.GetComponent<playerEngine>().SetSpeed(difficulty*2);
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
}
