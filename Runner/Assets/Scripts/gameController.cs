using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{

    private static gameController instance;

    private GameObject player;

    public void Awake()
    {
        if (instance != null)
            Destroy(gameObject);

        player = GameObject.FindGameObjectWithTag("Player");

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
