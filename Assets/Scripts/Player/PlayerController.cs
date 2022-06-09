using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    public Vector2 speed = new Vector2(50, 0);

    [SerializeField]
    public float jumpHeight = 10;

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

        Vector3 move = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        move *= Time.deltaTime;

        transform.Translate(move);

        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            body.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            jumping = true;
        }
    }

    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
             jumping = false;
        }
    }

}
