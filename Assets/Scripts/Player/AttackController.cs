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
    [SerializeField] public GameObject projectile;
    //public GameObject shotEffect;
    [SerializeField] public Transform shotPoint;
    [SerializeField] public Transform facedDirection;
    [SerializeField] public float StartTimeAttack; 


    [SerializeField] public GameObject[] skill1;
    [SerializeField] public GameObject[] skill2;
    [SerializeField] public GameObject[] skill3;
    [SerializeField] public GameObject[] skill4;


    [SerializeField] public int buttonPressed=-1;




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
            meleeStateMachine.SetNextState(new GroundEntryState());
        }

        if (Input.GetKeyDown(KeyCode.C) && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
             Debug.Log("ranged fired");

            meleeStateMachine.SetNextState(new RangedEntryState());
        }

        if (Input.GetKeyDown(KeyCode.Keypad0) && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            if(skill1.Length > 0){
                buttonPressed = 1;
                Debug.Log("skill 0 fired");
                meleeStateMachine.SetNextState(new SkillEntryState());
            }
            else {
                //play error sound
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad1) && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            if(skill2.Length > 0){
                Debug.Log("skill 1 fired");
                buttonPressed = 2;
                meleeStateMachine.SetNextState(new SkillEntryState());
            }
            else {
                //play error sound
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad2) && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            if(skill3.Length > 0){
                Debug.Log("skill 3 fired");
                buttonPressed = 3;
                meleeStateMachine.SetNextState(new SkillEntryState());
            }
            else {
                //play error sound
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad3) && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            if(skill4.Length > 0){
                Debug.Log("skill 4 fired");
                buttonPressed = 4;
                meleeStateMachine.SetNextState(new SkillEntryState());
            }
            else {
                //play error sound
            }
        }
    }

    void AddSkill(){
        
    }
}
