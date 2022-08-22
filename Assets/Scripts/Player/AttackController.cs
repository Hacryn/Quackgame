using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{

    private StateMachine meleeStateMachine;

    [SerializeField]
    private float baseDamage;

    public float Damage { get => baseDamage; }

    [SerializeField] public Collider2D hitbox;
    [SerializeField] public GameObject Hiteffect;
    [SerializeField] public LayerMask EnemyLayers;


    // Start is called before the first frame update
    void Start()
    {
        meleeStateMachine = GetComponent<StateMachine>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            meleeStateMachine.SetNextState(new MeleeEntryState());
        }
    }
}
