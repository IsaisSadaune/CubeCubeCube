using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {

    }

    public override void EnterState()
    {
        Debug.Log("J'entre dans l'état : " + stateMachine.currentPlayerState);
        
    }
    public override void ExitState()
    {

    }
    public override void FrameUpdate()
    {
        if (player.moveInput != Vector2.zero)
        {
            stateMachine.ChangeState(player.walkingState);
        }
        
    }

    public override void PhysicsUpdate()
    { 

    }
}
