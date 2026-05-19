
using UnityEngine;

public class ShieldState : PlayerState
{
    public ShieldState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {

    }
    Vector3 lastDirection;

    public override void EnterState()
    {
        //Debug.Log("J'entre dans l'état : " + stateMachine.currentPlayerState);
        player.rb.linearVelocity = Vector3.zero;
        player.shield.SetActive(true);
        lastDirection = player.transform.forward;
        player.shieldActivation = Time.time;
    }
    public override void ExitState()
    {
        player.shield.SetActive(false);
    }

    public override void FrameUpdate()
    {
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

    }
}
