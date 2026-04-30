using UnityEngine;

public class WalkingState : PlayerState
{
    public WalkingState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {

    }
    
    public override void EnterState()
    {
        //Debug.Log("J'entre dans l'état : " + stateMachine.currentPlayerState);
        player.animator.SetBool("isMoving", true);
        player.CreateDust();
    }
    public override void ExitState()
    {
        player.moveInput = Vector2.zero;
        player.animator.SetBool("isMoving", false);
        player.dust.Stop();
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
        if (player.isDead)
        {
            player.rb.linearVelocity = Vector3.zero;
            return;
        }

        if (stateMachine.currentPlayerState == player.idleState ||
            stateMachine.currentPlayerState == player.walkingState ||
            stateMachine.currentPlayerState == player.attackState)
        {
            Move();
            Rotate();
        }
    }

    void Move()
    {
        Vector2 input = player.moveInput;

        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = (camForward * input.y + camRight * input.x);

        if (moveDir.magnitude > 1f)
            moveDir.Normalize();

        float speedMultiplier = 1f;

        if (player.isTouchingWall && moveDir != Vector3.zero)
        {
            float dot = Vector3.Dot(moveDir, player.wallNormal);

            if (dot < 0f)
            {
                moveDir -= player.wallNormal * dot;
                speedMultiplier = 0.75f;
            }
        }

        Vector3 velocity = player.rb.linearVelocity;

        velocity.x = moveDir.x * player.speed * speedMultiplier;
        velocity.z = moveDir.z * player.speed * speedMultiplier;

        player.rb.linearVelocity = velocity;

        if (moveDir != Vector3.zero)
            player.direction = moveDir;
    }
    void Rotate()
{
    if (player.direction == Vector3.zero)
        return;

    Quaternion targetRotation = Quaternion.LookRotation(player.direction);

    player.transform.rotation = Quaternion.Slerp(
        player.transform.rotation,
        targetRotation,
        player.rotationSpeed * Time.fixedDeltaTime
    );
}
}
