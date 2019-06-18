using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    private float spawnZ = 0f;
    private float tileLength = 10f;
    private int amnTilesOnScreen = 7;

    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Start()
    {
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnTile();
        }

    }

    private void Update()
    {
        if (player.position.z > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(tilePrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;

    }
}
