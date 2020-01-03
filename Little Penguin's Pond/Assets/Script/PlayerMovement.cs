using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float horizontalMove = 0f;
    public float runSpeed = 40f;
    public bool jump = false;
    public Joystick joystick;

    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        if (FindObjectOfType<Joystick>() != null)
        {
            joystick = FindObjectOfType<Joystick>();
        }
    }

    private void Update()
    {
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
            if (joystick.Vertical >= 0.4f)
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("SpeedPercent", Mathf.Abs(horizontalMove));
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        Debug.Log("ON LAND");
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}