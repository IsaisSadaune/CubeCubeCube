using System.Collections;
using UnityEngine;

public class DashState : PlayerState
{
    public DashState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {

    }



    public override void EnterState()
    {
        //Debug.Log("J'entre dans l'état : " + stateMachine.currentPlayerState);
        //player.dashSound.Play();
        player.dash.StartDash();
    }
    public override void ExitState()
    {

    }
    
    public override void FrameUpdate()
    {

    }

    public override void PhysicsUpdate()
    {

    }
    
    
}
