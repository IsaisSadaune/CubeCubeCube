using UnityEngine;

public class SuperState : PlayerState
{
    public SuperState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {

    }
    Vector3 lastDirection;
    public override void EnterState()
    {
        base.EnterState();
        player.rb.linearVelocity = Vector3.zero;
        if(player.actualSuper == Super.GapClose)
        {
            return;
        }
        else if(player.actualSuper == Super.Heal)
        {
            
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (player.moveInput.magnitude > 0.1f)
        {
            lastDirection = player.direction;
            
            Quaternion targetRotation = Quaternion.LookRotation(player.direction);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, 0.1f);
            
        }
        else
        {
            Quaternion targetRotation = Quaternion.LookRotation(lastDirection);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, 0.1f);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}