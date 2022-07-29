using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 10;

    private float velocity;

    [SerializeField]
    public float jumpHeight = 15;

    private Vector3 move;

    private Rigidbody2D body;

    private SpriteRenderer sprite;

    private bool faceLeft;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        faceLeft = false;
    }

    // Update is called once per frame
    void Update()
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

        /*if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            jumping = true;
            speed.x = 15;
        }*/

        if (body.velocity.y == 0 && Input.GetKeyDown(KeyCode.Space)) {
            body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
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

}
