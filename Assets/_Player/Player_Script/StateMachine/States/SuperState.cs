using UnityEngine;

public class SuperState : PlayerState
{
    public SuperState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
        player.gapClose.GapClosing();
        player.hps.current_mp = 0;
    }

    public override void ExitState()
    {
        base.ExitState();
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