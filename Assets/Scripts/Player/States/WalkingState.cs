using UnityEngine;

public class WalkingState : PlayerState
{
    public WalkingState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {

    }
    
    public override void EnterState()
    {
        Debug.Log("J'entre dans l'état : " + stateMachine.currentPlayerState);
    }
    public override void ExitState()
    {
        player.moveInput = Vector2.zero;
    }
    public override void FrameUpdate()
    {

        if (player.moveInput == Vector2.zero || !player.isGrounded)
        {
            stateMachine.ChangeState(player.idleState);
        }

    }

    public override void PhysicsUpdate()
    {
        if (stateMachine.currentPlayerState == player.idleState || stateMachine.currentPlayerState == player.walkingState)
        {
            Vector3 move = new Vector3(player.moveInput.x, 0, player.moveInput.y).normalized;
            player.rb.linearVelocity = move * player.speed;

            Quaternion targetRotation = Quaternion.LookRotation(player.direction);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, 0.5f);
        }
    }
}
