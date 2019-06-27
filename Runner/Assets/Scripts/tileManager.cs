using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tileManager : MonoBehaviour
{
    public objectPool[] pools;
    private List<GameObject> activeTiles = new List<GameObject>();

    private float spawnZ = 0f;
    private float tileLength = 10f;
    private int amnTilesOnScreen = 7;
    private float safeZone = 20f;
    private int z = 0;


    private Transform player;

    private GameObject go;


    private void Start()
    {
        player = gameController.Instance.Player.transform;


        for (int i = 0; i < 3; i++)
        {
            SpawnTile(0);
        }
        for (int i = 0; i < 5; i++)
        {
            SpawnTile(Random.Range(0, 6));
        }

    }

    private void Update()
    {
        if (player.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile(Random.Range(0,6));

            DeleteTile();
        }
    }

    private void SpawnTile(int tileNumber=0)
    {
        int  x = Random.Range(0, 5);

        go = pools[tileNumber].GetNextAvailableObject() as GameObject;

        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);

    }

    private void DeleteTile()
    {
        activeTiles[z].SetActive(false);
        z++;

    }
}
