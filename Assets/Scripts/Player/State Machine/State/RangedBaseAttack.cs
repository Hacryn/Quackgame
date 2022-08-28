using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBaseAttack : RangedBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        //Attack
        //attackIndex = 3;
        duration = 0.5f;
        animator.SetTrigger("RangedAttack");
        Debug.Log("Ranged Attack " + " Fired!");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (fixedtime >= duration)
        {
             stateMachine.SetNextStateToMain();
        }
    }
}
