using Unity.VisualScripting;
using UnityEngine;
public class PlayerStateMachine
{
    public PlayerState currentPlayerState { get; set; }
    public bool stateLocked = false;

    public void Initialize(PlayerState startingState)
    {
        currentPlayerState = startingState;
        currentPlayerState.EnterState();
    }

    public void ChangeState(PlayerState newState)
    {
        if(stateLocked)
        return;


        currentPlayerState.ExitState();
        currentPlayerState = newState;
        currentPlayerState.EnterState();
    }

    public void LockState()
    {
        if(!stateLocked)
            stateLocked = true;
        else
            stateLocked = false;
    }
}