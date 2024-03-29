using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    [SerializeField] protected float attackCooldown;
    [SerializeField] protected float range;
    [SerializeField] protected float colliderDistance;
    [SerializeField] protected int damage;
    [SerializeField] protected BoxCollider2D boxCollider;
    [SerializeField] protected BoxCollider2D hitBox;
    [SerializeField] protected LayerMask playerLayer;
    [SerializeField] protected float timeHurt;
    [SerializeField] protected GameObject loot;
    protected float cooldownTimer = Mathf.Infinity;

    protected Animator anim;

    protected HealthTracker health;

    public virtual float Damage
    {
        set 
        {
            health.Value -= value;

            if (health.Value <= 0) {
                anim.SetTrigger("die");
                OnDeath();
            } else {
                anim.SetTrigger("hurt");
                StartCoroutine(ShowDamageCoroutine(timeHurt));
            }
        }
    }

    //private DemonHealth playerHealth;         vita del giocatore

    protected DemonPatrol patrolling;

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        health = GetComponent<HealthTracker>();
        patrolling = GetComponentInParent<DemonPatrol>();
    }

    protected virtual void OnDeath() 
    {
        Debug.Log(gameObject.name + " died");
        if (loot != null) {
            Instantiate(loot, gameObject.transform.position, Quaternion.identity);
        }
        gameObject.SetActive(false);
    }

    protected virtual void Update()
    {
        cooldownTimer += Time.deltaTime;

        // Attack only when player is in sight
        if(PlayerInSight())
        {
            if(cooldownTimer >= attackCooldown)
            {
                //Attack();
                cooldownTimer = 0;
                anim.SetTrigger("attack");
            }
        }

        // Patrolling if the player is not in sight
        if(patrolling != null)
        {
            patrolling.enabled = !PlayerInSight();
        }
    }

    // Function that see if the player is in the range of the enemy
    protected virtual bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 
            0, Vector2.left, 0, playerLayer);
/*      
        if(hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<DemonHealth>();
        }
*/
        return hit.collider != null;
    }

    // Function that visualize the area where the enemy attacks
    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    public virtual void Attack()
    {
        Collider2D [] player = new Collider2D[10];
        List<Collider2D> damaged = new List<Collider2D>();
        int collision = PhysicsScene2D.OverlapCollider(hitBox, player, playerLayer);

        for (int i = 0; i < collision; i++) {
            if (!damaged.Contains(player[i])) {
                player[i].gameObject.
                GetComponentInParent<DamageController>().Damage = 25;
                Debug.Log(gameObject.name + "has hit player");
                damaged.Add(player[i]);
            }
        }

    }

    protected virtual IEnumerator ShowDamageCoroutine(float time)
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(time);
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
}