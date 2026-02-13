using UnityEngine;

public class PlayerState
{

    public PlayerState(Player player, PlayerStateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

    protected Player player;
    protected PlayerStateMachine stateMachine;

    public virtual void EnterState() {}

    public virtual void ExitState() {}

    public virtual void FrameUpdate() {}

    public virtual void PhysicsUpdate() {}


    public virtual void DoCheck() {}
    

}