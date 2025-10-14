
using UnityEngine;

public class ShieldState : PlayerState
{
    public ShieldState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {

    }
    Vector3 lastDirection;

    public override void EnterState()
    {
        Debug.Log("J'entre dans l'état : " + stateMachine.currentPlayerState);
        player.shield.SetActive(true);
        lastDirection = player.transform.forward;
    }
    public override void ExitState()
    {
        player.shield.SetActive(false);
    }

    public override void FrameUpdate()
    {
        if (player.shield.activeSelf)
        {
            //Diminuer les dégats subits
        }
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

    }
}
