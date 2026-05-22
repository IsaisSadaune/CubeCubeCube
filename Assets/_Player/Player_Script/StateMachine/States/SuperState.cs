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
            Vector3 direction = new Vector3(player.moveInput.x, 0f, player.moveInput.y);
            lastDirection = player.direction;
            
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, Time.deltaTime * player.rotationSpeed);
        }        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}