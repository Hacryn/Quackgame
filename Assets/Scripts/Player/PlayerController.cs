using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    public Vector2 speed = new Vector2(20, 0);

    [SerializeField]
    public float jumpHeight = 10;

    public Vector3 move;

    private bool jumping;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        move = new Vector3(speed.x * inputX, speed.y * inputY, 0);

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
            speed.x = 15;
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
