using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {

    }
    
    public override void EnterState()
    {
        
    }
    public override void ExitState()
    {

    }
    public override void FrameUpdate()
    {
        player.rb.linearVelocity = new Vector3(Vector3.zero.x, player.rb.linearVelocity.y, Vector3.zero.z);
        if (player.moveInput != Vector2.zero && player.isGrounded == true)
        {
            stateMachine.ChangeState(player.walkingState);
        }
        
    }

    public override void PhysicsUpdate()
    { 

    }
}
