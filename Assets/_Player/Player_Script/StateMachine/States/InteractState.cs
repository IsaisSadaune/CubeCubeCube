using UnityEngine;

public class InteractState : PlayerState
{
    public InteractState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
        player.playerInput.SwitchCurrentActionMap("UI");
    }

    public override void ExitState()
    {
        base.ExitState();
        player.playerInput.SwitchCurrentActionMap("Gameplay");
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
