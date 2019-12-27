using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float horizontalMove = 0f;
    public float verticalMove = 0f;
    public float runSpeed = 40f;
    public bool jump = false;
    public Joystick joystick;

    private void Start()
    {
        if (FindObjectOfType<Joystick>() != null)
        {
            joystick = FindObjectOfType<Joystick>();
        }
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
        if (joystick != null)
        {
            if (joystick.Horizontal > .2f)
            {
                horizontalMove = runSpeed;
            }
            else if (joystick.Horizontal < -.2f)
            {
                horizontalMove = -runSpeed;
            }
            else
            {
                horizontalMove = 0f;
            }
            verticalMove = joystick.Vertical * runSpeed;
        }
        if (Input.GetKeyDown(KeyCode.W) || joystick.Vertical >= 0.4f)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}