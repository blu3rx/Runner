using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeBrain : MonoBehaviour
{
    public List<GameObject> bridgeList;
    List<GameObject> goList;
    List<GameObject> objectOne;


    public int poolSize;
    int x = 0;


    private void Awake()
    {
        goList = new List<GameObject>();
        for (int i=0; i< bridgeList.Count; i++)
        {
           
            for (int j = 0; j < poolSize; j++)
            {
                GameObject tempGO = Instantiate(bridgeList[i]) as GameObject;
                tempGO.transform.SetParent(transform);
                goList.Add(tempGO);
                goList[x].SetActive(false);
                x++;
            }
            
        }


    }

    public GameObject GetNextAvailableObject()
    {
        for (int i = 0; i < x; i++)
        {
            if (!goList[i].activeSelf)
            {
                goList[i].SetActive(true);
                return goList[i];
            }

        }
        return null;
    }



}
