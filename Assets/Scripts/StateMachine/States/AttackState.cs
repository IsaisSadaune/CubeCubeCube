using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AttackState : PlayerState
{
    public AttackState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {

    }

    int comboCount;

    public override void EnterState()
    {
        Debug.Log("J'entre dans l'état : " + stateMachine.currentPlayerState);
    }
    public override void ExitState()
    {

    }
    public override void FrameUpdate()
    {
        player.attack.StoppingAttack();
    }

    public override void PhysicsUpdate()
    {

    }

}
