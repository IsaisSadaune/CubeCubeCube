using Unity.AppUI.UI;
using UnityEngine;

public class MenuState : PlayerState
{
    public MenuState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {

    }



    public override void EnterState()
    {
        Debug.Log("J'entre dans l'état : " + stateMachine.currentPlayerState);
        
    }
    public override void ExitState()
    {
        player.playerInput.SwitchCurrentActionMap("Gameplay");
    }
    
    public override void FrameUpdate()
    {
              
    }

    public override void PhysicsUpdate()
    {

    }
    
    
}