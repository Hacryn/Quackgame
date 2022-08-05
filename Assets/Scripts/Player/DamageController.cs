using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{

    private Rigidbody2D rbody;
    private BoxCollider2D box;
    private CircleCollider2D circle;
    private SpriteRenderer spriteRen;
    public int impulseVal=8;
    public LayerMask maskEnemies;

    //public Transform prova=transform.GetChild(0);

    //make it a global variable
    public int totalHp=100;

    //invulnerability time
    public int recoveryTime=2;

    private bool invincible=false;
    public Animator anim;

    Vector3 lastVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        box = GetComponentInChildren<BoxCollider2D>();
        circle =  GetComponentInChildren<CircleCollider2D>();
        spriteRen = GetComponentInChildren<SpriteRenderer>();
        box.enabled=true;
        circle.enabled=true;
        spriteRen.enabled=true;
   }

    void Update(){

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
           Debug.Log("There is a collision");

        if (( maskEnemies & (1 << collision.gameObject.layer)) != 0)
        {
            Debug.Log("you collided with an Enemy");
            StartCoroutine(heroDamage(10, collision.gameObject));
        }
    }

    IEnumerator heroDamage(int damageSource, GameObject colEnemy) {
        if(invincible)
            yield break;
        invincible = true;
        spriteRen.color = Color.red;
        rbody.velocity = new Vector2((transform.position.x - colEnemy.transform.position.x)* impulseVal, rbody.velocity.y);
        
        //delayspecified amount
        yield return new WaitForSeconds(recoveryTime);
        totalHp-=damageSource;
        spriteRen.color = Color.white;
        invincible = false;
        Debug.Log("damage took");
        if (totalHp == 0)
            Death ();
    }

    void Death(){

    }

}
