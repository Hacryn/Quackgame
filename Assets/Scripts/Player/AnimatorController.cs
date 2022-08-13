using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorController : MonoBehaviour
{
    
    public Animator animator;
    private Rigidbody2D body;
    private PlayerController move;

    private bool wasGrounded;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        move = GetComponent<PlayerController>();
        wasGrounded = true;
    }

    void Update()
    {
        animator.SetFloat("speed",Mathf.Abs(Input.GetAxis("Horizontal")));

        if (!wasGrounded && move.IsNotJumping()) {
            wasGrounded = true;
            Land();
        }
   
    }

    public void Jump() {
        animator.SetBool("isJumping", true);
        wasGrounded = false;
    } 

    public void Land() {
        animator.SetBool("isJumping", false);
    }

    public void Roll() {
        animator.SetTrigger("isRolling");
    }

}
