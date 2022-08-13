using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBaseState : State
{
    // How long this state should be active for before moving on
    public float duration;
    // Cached animator component
    protected Animator animator;
    // bool to check whether or not the next attack in the sequence should be played or not
    protected bool shouldCombo;
    // The attack index in the sequence of attacks
    protected int attackIndex;



    // The cached hit collider component of this attack
    protected Collider2D hitCollider;
    // Cached already struck objects of said attack to avoid overlapping attacks on same target
    private List<Collider2D> collidersDamaged;
    // The Hit Effect to Spawn on the afflicted Enemy
    private GameObject HitEffectPrefab;

    public LayerMask basicEnemyLayers;


    // Input buffer Timer
    private float AttackPressedTimer = 0;

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator = GetComponent<Animator>();
        collidersDamaged = new List<Collider2D>();
        hitCollider = GetComponent<ComboCharacter>().hitbox;
        HitEffectPrefab = GetComponent<ComboCharacter>().Hiteffect;
        basicEnemyLayers = GetComponent<ComboCharacter>().EnemyLayers;

    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        AttackPressedTimer -= Time.deltaTime;

        if (animator.GetFloat("Weapon.Active") > 0f)
        {
            //Debug.Log("you're attacking:");
            Attack();
        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            AttackPressedTimer = 2;
        }

        if (animator.GetFloat("AttackWindow.Open") > 0f && AttackPressedTimer > 0)
        {
            shouldCombo = true;
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    protected void Attack()
    {
        Collider2D[] collidersToDamage = new Collider2D[10];
        ContactFilter2D filter = new ContactFilter2D();
        filter.useTriggers = true;
        int colliderCount = PhysicsScene2D.OverlapCollider(hitCollider, collidersToDamage, basicEnemyLayers);
        //Debug.Log(colliderCount);
        for (int i = 0; i < colliderCount; i++)
        {

            if (!collidersDamaged.Contains(collidersToDamage[i]))
            {
                //GameObject.Instantiate(HitEffectPrefab, collidersToDamage[i].transform);
                collidersToDamage[i].GetComponent<Enemy>().takeDamage(50);
                Debug.Log("Enemy Has Taken:" + attackIndex + "Damage");
                collidersDamaged.Add(collidersToDamage[i]);
            }
        }
    }

}
