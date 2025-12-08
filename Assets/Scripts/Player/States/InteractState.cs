using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class InteractState : PlayerState
{
    public InteractState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {

    }


    public override void EnterState()
    {
        base.EnterState();
        //Debug.Log("J'entre dans l'état : " + stateMachine.currentPlayerState);
        player.playerInput.SwitchCurrentActionMap("UI");
        
    }
    public override void ExitState()
    {
        base.ExitState();
        player.playerInput.SwitchCurrentActionMap("Gameplay");
        player.emptyText.enabled = false;
        player.dialogue_Manager.dialogue_Background.enabled = false;
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
