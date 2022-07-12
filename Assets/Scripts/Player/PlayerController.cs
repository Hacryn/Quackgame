using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private const float SPEED = 10;

    private float speed;

    [SerializeField]
    public float jumpHeight = 10;

    public Vector3 move;

    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift)) {
            speed = SPEED * 2;
        } else {
            speed = SPEED;
        }

        move = new Vector3(speed * inputX, 0, 0);

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

    /*private void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            jumping = false;
            speed.x = 20;
        }
    }*/

}
