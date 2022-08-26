using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    //public GameObject destroyEffect;

    private void Start()
    {

        Invoke("DestroyProjectile", lifeTime);
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale *= Mathf.Sign(transform.localRotation.w); 
        gameObject.transform.localScale = currentScale;
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null) {
/*

            Collider2D[] collidersToDamage = new Collider2D[10];
            ContactFilter2D filter = new ContactFilter2D();
            filter.useTriggers = true;
            int colliderCount = PhysicsScene2D.OverlapCollider(hitCollider, collidersToDamage, basicEnemyLayers);
            for (int i = 0; i < colliderCount; i++)
            {

                if (!collidersDamaged.Contains(collidersToDamage[i]))
                {
                    GameObject enemy = collidersToDamage[i].gameObject;
                    enemy.GetComponent<Demon>().Damage = damage;
                    Debug.Log(enemy.name + "has taken:" + damage + "points of damage");
                    collidersDamaged.Add(collidersToDamage[i]);
                }
            }


            if (hitInfo.collider.CompareTag("D")) {

                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            */

            DestroyProjectile();
        }
        transform.Translate(Vector2.right * gameObject.transform.localScale.x * speed * Time.deltaTime);
    }

    void DestroyProjectile() {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
       }
}