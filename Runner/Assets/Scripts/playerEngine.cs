using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEngine : MonoBehaviour
{
    

    
    private Vector3 gridPosition;
    private Vector2 startTouchPosition, endTouchPosition;


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

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if (endTouchPosition.x < startTouchPosition.x)
            {
                gridPosition.x -= changeGrid;

                if (gridPosition.x < 0)
                    gridPosition.x = -changeGrid;
            }else if(endTouchPosition.x > startTouchPosition.x)
            {
                gridPosition.x += changeGrid;

                if (gridPosition.x > 0)
                    gridPosition.x = changeGrid;
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
        moveSpeed = 7f+modifier;
    }
}
