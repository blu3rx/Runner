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

    public GameObject GetNextAvailableObject1()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (poolDict[0][i].activeSelf)
            {
                poolDict[0][i].SetActive(true);
                return poolDict[0][i];
            }

        }
        return null;
    }



}
