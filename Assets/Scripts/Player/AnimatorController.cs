using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorController : MonoBehaviour
{


    public Animator animator;
    private Rigidbody2D body;
    [SerializeField] public float jumpingTollerance = 0.01f;

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;  // Whether or not the player is grounded.
    [SerializeField] private LayerMask m_WhatIsGround; // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck; // A position marking where to check if the player is grounded.

    

    public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

    private void Awake()
	{
		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

	}
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        

    }

    private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed",Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetBool("isJumping", true);
        }
   
    }

    private bool IsNotJumping(float tollerance) {
        return body.velocity.y < tollerance && body.velocity.y > -tollerance;
    }

    public void OnLanding(){
        animator.SetBool("isJumping", false);
    }

/*    private bool isGrounded(){
        float extraHeightText= .01f;
        Pyshic2D.RayCast(circleCollider.bounds.center, Vector2.down, circleCollider.bounds.extents.y + extrHeightText);
    }
*/
}
