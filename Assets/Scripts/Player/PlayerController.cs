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
    private AudioClip jumpSound;

    private Vector3 move;
    
    [SerializeField]
    private float rollPower = 5f;

    [SerializeField]
    private float rollTime = 0.3f;

    [SerializeField]   
    private float rollCooldown = 0.5f;

    private Vector3 move;
    private Rigidbody2D body;

    private BoxCollider2D box;
    private CircleCollider2D circle;

    private AnimatorController animx;
    
    private bool faceLeft;

    private bool canRoll=true;

    private bool blockMovement;

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

        MovePlayer();

        Jump();

        Roll();
    }

    public bool IsJumping() {
        return body.velocity.y >= jumpingTollerance || body.velocity.y <= -jumpingTollerance;
    }

    public void Bounce(GameObject obj, int impulse)
    {
        BlockMovement();
        body.velocity = new Vector2((transform.position.x - obj.transform.position.x)* impulse, body.velocity.y);
        Invoke("UnblockMovement", 0.3f);
    }

    public void BlockMovement() 
    {
        blockMovement = true;
    }

    public void UnblockMovement()
    {
        blockMovement = false;
    }

    private void MovePlayer()
    {
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
    }

    private void FlipPlayer()
    {
        Vector3 scale = transform.localScale;
        scale.x = scale.x * -1;
        transform.localScale = scale;
    }

    private void Jump()
    {
        if (!IsJumping() && Input.GetKeyDown(KeyCode.Space)) {
            body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            animx.Jump();
            SoundTracker.instance.PlaySound(jumpSound);
        }
    }

    private void Roll()
    {
        if (canRoll && Input.GetKeyDown(KeyCode.X)) {
            animx.Roll();
            StartCoroutine(RollCoroutine());
        }
    }

    private IEnumerator RollCoroutine()
    {
        BlockMovement();
        canRoll=false;
        box.isTrigger=true;
        circle.isTrigger=true;

        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;
        body.velocity = new Vector2(transform.localScale.x * rollPower, 0f);
        yield return new WaitForSeconds(rollTime);
        body.gravityScale = originalGravity;
        box.isTrigger=false;
        circle.isTrigger=false;

        yield return new WaitForSeconds(rollCooldown);
        canRoll=true;
        UnblockMovement();
    }

}
