using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float horizontalMove = 0f;
    public float verticalMove = 0f;
    public float runSpeed = 40f;



    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;



    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove, false, false);
    }
}
