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
        player.rb.linearVelocity = Vector3.zero;
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
            Vector2 input = player.moveInput;

// Récupère les directions avant/droite de la caméra
Vector3 camForward = Camera.main.transform.forward;
Vector3 camRight = Camera.main.transform.right;

// On garde le mouvement sur le plan XZ
camForward.y = 0f;
camRight.y = 0f;
camForward.Normalize();
camRight.Normalize();

// Combine les entrées pour obtenir la direction finale
Vector3 move = (camForward * input.y + camRight * input.x).normalized;

// Applique la vitesse
player.rb.linearVelocity = move * player.speed;

            Quaternion targetRotation = Quaternion.LookRotation(player.direction);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, 0.5f);
        }
    }
}
