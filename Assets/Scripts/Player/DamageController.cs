using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageController : MonoBehaviour
{

     [SerializeField]
    private int bounceForce=8;

    [SerializeField]
    public LayerMask maskEnemies;

    [SerializeField]
    private float recoveryTime;

    [SerializeField]
    private float bounceDamage;

    [SerializeField]
    private string baseLevel;

    // Use this to inflict damage to the player
    public float Damage
    {
        set 
        {
            if (value > 0) StartCoroutine(SetDamage(value));
            else Debug.Log("Warning: Damage to the player cannot be equal or lower that 0");
        }
    }

    private BoxCollider2D box;
    private CircleCollider2D circle;
    private SpriteRenderer spriteRen;
    private PlayerController move;
    private HealthTracker health;
    private bool invincible;


    void Start()
    {
        box = GetComponentInChildren<BoxCollider2D>();
        circle =  GetComponentInChildren<CircleCollider2D>();
        spriteRen = GetComponentInChildren<SpriteRenderer>();
        move = GetComponent<PlayerController>();
        health = GetComponent<HealthTracker>();
        box.enabled=true;
        circle.enabled=true;
        spriteRen.enabled=true;
        invincible = false;
    }

    void OnValidate() 
    {
        if (bounceDamage <= 0) bounceDamage = 10;
        if (recoveryTime < 0) recoveryTime = 0.5f;
    }

    // Bounce back when player hits an enemy and take some damage
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (( maskEnemies & (1 << collision.gameObject.layer)) != 0)
        {
            move.Bounce(collision.gameObject, bounceForce);
            StartCoroutine(SetDamage(bounceDamage));
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(baseLevel, LoadSceneMode.Single);
    }

    // Set the amount of damage the player takes and set they invincible
    private IEnumerator SetDamage(float damage) 
    {
        if(invincible)
            yield break;
        invincible = true;
        spriteRen.color = Color.red;
        yield return new WaitForSeconds(recoveryTime);
        if (health == null) Debug.Log("Warning: Player has no Health Tracker!");
        else health.Value -= damage;
        if (health.Value == 0) Die();
        spriteRen.color = Color.white;
        invincible = false;
    }

}
