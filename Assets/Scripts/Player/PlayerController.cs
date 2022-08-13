using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 10;

    private float velocity;

    [SerializeField]
    public float jumpHeight = 1;

    [SerializeField]
    public float jumpingTollerance = 0.01f;

    [SerializeField]
    private float rollPower = 5f;

    [SerializeField]
    private float rollTime = 0.6f;

    [SerializeField]   
    private float rollCooldown = 1f;

    private Vector3 move;
    private Rigidbody2D body;

    private BoxCollider2D box;
    private CircleCollider2D circle;

    private AnimatorController animx;
    
    private bool faceLeft;

    private bool canRoll=true;

    private bool blockMovement;
    public bool BlockMovement { set => blockMovement = value;}

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        box = GetComponentInChildren<BoxCollider2D>();
        circle =  GetComponentInChildren<CircleCollider2D>();
        faceLeft = false;
        animx = GetComponent<AnimatorController>();
        blockMovement = false;
    }

    void Update()
    {

        if(blockMovement) return;
        
        float inputX = Input.GetAxis("Horizontal");

        if (!faceLeft && inputX < 0) {
            faceLeft = true;
            FlipPlayer();
        } else if (faceLeft && inputX > 0) {
            faceLeft = false;
            FlipPlayer();
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            velocity = speed * 2;
        } else {
            velocity = speed;
        }

        move = new Vector3(velocity * inputX, 0, 0);

        move *= Time.deltaTime;

        transform.Translate(move);

        if (IsNotJumping() && Input.GetKeyDown(KeyCode.Space)) {
            body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            animx.Jump();
        }

         if (canRoll && Input.GetKeyDown(KeyCode.X)) {
            animx.Roll();
            StartCoroutine(Roll());
        }
    }

    void FlipPlayer()
    {
        Vector3 scale = transform.localScale;
        scale.x = scale.x * -1;
        transform.localScale = scale;
    }

    public bool IsNotJumping() {
        return body.velocity.y < jumpingTollerance && body.velocity.y > -jumpingTollerance;
    }

    public bool IsJumping() {
        return body.velocity.y >= jumpingTollerance && body.velocity.y <= -jumpingTollerance;
    }

    public IEnumerator Roll(){
        BlockMovement = true;
        canRoll=false;
        box.isTrigger=true;
        circle.isTrigger=true;

        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;
        body.velocity = new Vector2(transform.localScale.x * rollPower, 0f);
        //trail effect + other nifty stuff
        yield return new WaitForSeconds(rollTime);
        body.gravityScale = originalGravity;
        box.isTrigger=false;
        circle.isTrigger=false;

        yield return new WaitForSeconds(rollCooldown);
        canRoll=true;
        BlockMovement = false;
    }

}
