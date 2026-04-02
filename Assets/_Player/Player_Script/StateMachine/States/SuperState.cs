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
    }

    public override void ExitState()
    {
        base.ExitState();
        player.hps.current_mp = 0;
        player.hps.rageBar.DecreaseBarValue(player.hps.mp_max);
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