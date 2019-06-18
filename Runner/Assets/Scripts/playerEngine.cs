using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEngine : MonoBehaviour
{
    

    
    private Vector3 gridPosition;

    public float moveSpeed = 5.0f;
    private float speed = 1f;
    public float changeGrid = 1.5f;


    void Start()
    {
       
        gridPosition = new Vector3Int(0, 0, 0);


    }

    // Update is called once per frame
    void Update()
    {
        

        //X- Left and Right
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gridPosition.x -= changeGrid;

            if (gridPosition.x < 0)
                gridPosition.x = -changeGrid;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gridPosition.x += changeGrid;

            if (gridPosition.x > 0)
                gridPosition.x = changeGrid;
        }



        //Z - Foward and Bacward
        speed += moveSpeed * Time.deltaTime;


        transform.position = new Vector3(Mathf.Clamp(gridPosition.x, -changeGrid, changeGrid),transform.position.y,speed);

        



    }
}
