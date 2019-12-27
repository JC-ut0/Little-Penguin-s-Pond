using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float horizontalMove = 0f;
    public float verticalMove = 0f;
    public float runSpeed = 40f;
    public bool jump = false;



    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
        jump = Input.GetKeyDown(KeyCode.W);
        controller.Move(horizontalMove, false, jump);


    }

    private void FixedUpdate()
    {
    }
}
