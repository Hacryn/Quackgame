using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{

    private StateMachine meleeStateMachine;

    [SerializeField]
    private float baseDamage;

    public float Damage { get => baseDamage; set => baseDamage = value; }

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

    void OnValidate() 
    {
        skill1 = new GameObject[5];
        skill2 = new GameObject[5];
        skill3 = new GameObject[5];
        skill4 = new GameObject[5];
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

        if (Input.GetKeyDown(KeyCode.Alpha1) && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            if(skill1[0] != null){
                buttonPressed = 1;
                Debug.Log("skill 0 fired");
                meleeStateMachine.SetNextState(new SkillEntryState());
            }
            else {
                //play error sound
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            if(skill2[0] != null){
                Debug.Log("skill 1 fired");
                buttonPressed = 2;
                meleeStateMachine.SetNextState(new SkillEntryState());
            }
            else {
                //play error sound
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            if(skill3[0] != null){
                Debug.Log("skill 3 fired");
                buttonPressed = 3;
                meleeStateMachine.SetNextState(new SkillEntryState());
            }
            else {
                //play error sound
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            if(skill4[0] != null){
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
