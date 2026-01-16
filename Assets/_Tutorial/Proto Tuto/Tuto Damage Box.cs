using UnityEngine;

public class TutoDamageBox : MonoBehaviour
{
    public Transform respawnPoint; 
    public Player playerState;
    public GameObject playerGo; 
    
    void OnTriggerEnter()
    {
        if (playerState.stateMachine.currentPlayerState != playerState.dashState)
            playerGo.transform.position = respawnPoint.position;
    }
}
