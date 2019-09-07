using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeBrain : MonoBehaviour
{
    public List<GameObject> bridgeList;



    Dictionary<int,List<GameObject>> poolDict = new Dictionary<int, List<GameObject>>();

    public int poolSize;


    private void Awake()
    {
        for (int i=0; i< bridgeList.Count; i++)
        {
             poolDict.Add(i, new List<GameObject>());

            for (int j = 0; j < poolSize; j++)
            {
                GameObject tempGO = Instantiate(bridgeList[i]) as GameObject;
                tempGO.transform.SetParent(transform);
                poolDict[i].Add(tempGO);
                poolDict[i][j].SetActive(false);
            }
            
        }


    }

    public GameObject GetNextAvailableObject()
    {
        int x = Random.Range(0, poolDict.Count);

        for (int i = 0; i < poolSize; i++)
        {
            if (!poolDict[x][i].activeSelf)
            {
                poolDict[x][i].SetActive(true);
                return poolDict[x][i];
            }

        }
        return null;
    }



}
