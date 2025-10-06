using UnityEngine;
using UnityEngine.Rendering;

public class InteractState : PlayerState
{
    public InteractState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {

    }


    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("J'entre dans l'état : " + stateMachine.currentPlayerState);
        player.playerInput.actions = player.UIActions;
    }
    public override void ExitState()
    {
        base.ExitState();
        player.playerInput.actions = player.gameplayActions;
    }
    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
