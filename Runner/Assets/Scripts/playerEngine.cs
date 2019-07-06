using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEngine : MonoBehaviour
{
    

    
    private Vector3 gridPosition;


    [SerializeField]private float moveSpeed = 3.0f;
    private float speed = 0f;
    public float changeGrid = 1.5f;


    


    void Start()
    {
       
        gridPosition = new Vector3Int(0, 0, 0);
        

    }

    void Update()
    {
        Debug.Log(moveSpeed);

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

        if (Input.GetMouseButton(0))
        {
            //Right Side
            if (Input.mousePosition.x > Screen.width / 2)
            {
                gridPosition.x += changeGrid;

                if (gridPosition.x > 0)
                    gridPosition.x = changeGrid;
            }
            else
            {
                gridPosition.x -= changeGrid;

                if (gridPosition.x < 0)
                    gridPosition.x = -changeGrid;
            }
        }



        //Z - Foward and Bacward
        speed += moveSpeed * Time.deltaTime;


        transform.position = new Vector3(Mathf.Clamp(gridPosition.x, -changeGrid, changeGrid),transform.position.y,speed);

        



    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "box")
        {
            gameController.Instance.GameOver = true;
        }
    }


    public void SetSpeed(float modifier)
    {
        moveSpeed += modifier;
    }
}
