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

    private Vector3 move;

    private Rigidbody2D body;

    private BoxCollider2D box;
    private CircleCollider2D circle;

    //private SpriteRenderer sprite;

    public Animator anim;
    private bool faceLeft;

    private bool canRoll=true;
    private bool isRolling=false;
    public float rollPower = 5f;
    private float rollTime = 0.6f;    
    private float rollCooldown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //sprite = GetComponent<SpriteRenderer>();
        box = GetComponentInChildren<BoxCollider2D>();
        circle =  GetComponentInChildren<CircleCollider2D>();
        faceLeft = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(isRolling){
            return;
        }
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

        /*if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            jumping = true;
            speed.x = 15;
        }*/

        if (IsNotJumping(jumpingTollerance) && Input.GetKeyDown(KeyCode.Space)) {
            body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }

         if (canRoll && Input.GetKeyDown(KeyCode.X)) {
            anim.SetTrigger("isRolling");
            StartCoroutine(roll());
        }
    }

    void FixedUpdate()
    {
        
    }

    void FlipPlayer()
    {
        Vector3 scale = transform.localScale;
        scale.x = scale.x * -1;
        transform.localScale = scale;
    }

    /*private void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        { 
            jumping = false;
            speed.x = 20;
        }
    }*/

    private bool IsNotJumping(float tollerance) {
        return body.velocity.y < tollerance && body.velocity.y > -tollerance;
    }

    private IEnumerator roll(){
        isRolling=true;
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

        isRolling = false;
        yield return new WaitForSeconds(rollCooldown);
        canRoll=true;
    }

}
