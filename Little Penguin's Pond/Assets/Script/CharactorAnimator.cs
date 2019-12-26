using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorAnimator : MonoBehaviour
{
    const float locomotionAnimationSmoothTime = .1f;

    float speedPrecent;

    Animator animator;
    PlayerMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        speedPrecent = movement.horizontalMove * movement.horizontalMove;
        animator.SetFloat("SpeedPercent", speedPrecent, locomotionAnimationSmoothTime, Time.deltaTime);
    }
}
