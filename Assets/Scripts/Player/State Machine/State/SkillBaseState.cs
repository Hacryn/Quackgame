using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBaseState : State
{
    // How long this state should be active for before moving on
    public float duration;
    // Cached animator component
    protected Animator animator;
    // bool to check whether or not the next attack in the sequence should be played or not
    protected bool shouldCombo;

    protected GameObject projectile;
    protected GameObject shotEffect;
    protected Transform shotPoint;
    protected Transform facedDirection;
    protected Animator camAnim;


    private float timeBtwShots = 0;
    protected float startTimeBtwShots; 

    // The cached hit collider component of this attack
    protected Collider2D hitCollider;
    // Cached already struck objects of said attack to avoid overlapping attacks on same target
    private List<Collider2D> collidersDamaged;
    // The Hit Effect to Spawn on the afflicted Enemy
    private GameObject HitEffectPrefab;

    public LayerMask basicEnemyLayers;

    private float damage;

    protected float SkillSelected;

    protected float cooldown;

    // Input buffer Timer
    private float AttackPressedTimer = 0;

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator = GetComponent<Animator>();
        collidersDamaged = new List<Collider2D>();
        hitCollider = GetComponent<AttackController>().hitbox;
        HitEffectPrefab = GetComponent<AttackController>().Hiteffect;
        basicEnemyLayers = GetComponent<AttackController>().EnemyLayers;
        damage = GetComponent<AttackController>().Damage;

        this.facedDirection = GetComponent<AttackController>().facedDirection;
        this.shotPoint = GetComponent<AttackController>().shotPoint;
        this.startTimeBtwShots = GetComponent<AttackController>().StartTimeAttack;

        
        this.SkillSelected = GetComponent<AttackController>().buttonPressed;
        Debug.Log(SkillSelected);

        switch(SkillSelected){
            case 1: {
                this.projectile = GetComponent<AttackController>().skill1[0];
                break;
            }
            case 2: {
                this.projectile = GetComponent<AttackController>().skill2[0];
                break;
            }
            case 3: {
                this.projectile = GetComponent<AttackController>().skill3[0];
                break;
            }
            case 4:{
                this.projectile = GetComponent<AttackController>().skill4[0];
                break;
            }
            default: {
                this.projectile = GetComponent<AttackController>().projectile;
                break;
            }
        }

    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        AttackPressedTimer -= Time.deltaTime;
        RangedAttack();

        if (Input.GetKeyDown(KeyCode.C))
        {
            AttackPressedTimer = 2;
        }

        if (AttackPressedTimer > 0)
        {
            shouldCombo = true;
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    protected void RangedAttack()
    {


        if (timeBtwShots <= 0)
        {

            Quaternion rotation = new Quaternion( shotPoint.localRotation.x, shotPoint.localRotation.y, shotPoint.localRotation.z, shotPoint.localRotation.w*Mathf.Sign(facedDirection.localScale.x));
            //Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
            //camAnim.SetTrigger("shake");
            GameObject.Instantiate(projectile, shotPoint.position, rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else {
            timeBtwShots -= Time.deltaTime;
        }

    }

}
