using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEntryState : State
{

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        
        stateMachine.SetNextState(new RangedBaseAttack());
    }
}
