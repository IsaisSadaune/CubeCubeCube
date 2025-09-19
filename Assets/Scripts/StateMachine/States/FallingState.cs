using UnityEngine;

public class FallingState : PlayerState
{
    public FallingState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
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
        
    }
}
