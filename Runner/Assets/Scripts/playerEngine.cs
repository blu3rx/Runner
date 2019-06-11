using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEngine : MonoBehaviour
{
    private CharacterController controller;

    private Vector3 moveVector;

    public float moveSpeed = 5.0f;
    private float verticalVelocity= 0.0f;
    private float gravity = 9.8f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity*Time.deltaTime;
        }

        //X - Left and Right
        moveVector.x = Input.GetAxisRaw("Horizontal")*moveSpeed;

        //Y - Up and Down
        moveVector.y = verticalVelocity;

        //Z - Foward and Bacward
        moveVector.z = moveSpeed;

        controller.Move(moveVector*Time.deltaTime);
    }
}
