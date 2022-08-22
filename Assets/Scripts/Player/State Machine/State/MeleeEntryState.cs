using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEntryState : State
{

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        
        stateMachine.SetNextState(new GroundEntryState());
    }
}
