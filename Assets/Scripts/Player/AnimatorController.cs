using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorController : MonoBehaviour
{
    
    [SerializeField]
    private Animator animator;

    private PlayerController move;
    private bool wasGrounded;

    void Start()
    {
        move = GetComponent<PlayerController>();
        wasGrounded = true;
    }

    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (!wasGrounded && !move.IsJumping()) {
            Land();
        }
   
    }

    public void Jump() {
        animator.SetBool("isJumping", true);
        wasGrounded = false;
    } 

    public void Land() {
        animator.SetBool("isJumping", false);
        wasGrounded = true;
    }

    public void Roll() {
        animator.SetTrigger("isRolling");
    }

}
