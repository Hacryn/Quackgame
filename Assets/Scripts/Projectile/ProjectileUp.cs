using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileUp : MonoBehaviour {

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
            GameObject enemy = hitInfo.collider.gameObject;
            enemy.GetComponent<Demon>().Damage = damage;
            Debug.Log(enemy.name + "has taken:" + damage + "points of damage");
            DestroyProjectile();
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile() {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
       }
}