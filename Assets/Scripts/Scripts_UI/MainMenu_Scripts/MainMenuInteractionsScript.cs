using MoreMountains.Feedbacks;
using UnityEngine;

public class MainMenuInteractionsScript : MonoBehaviour
{
    [SerializeField] MMF_Player startGameFeedbacks;
    bool GameStarted;

    private void Update()
    {
        if (Input.anyKey && !GameStarted) 
        {
            GameStarted = true;
            TriggerGameStart();
        }
    }

    private void TriggerGameStart()
    {
        Cursor.lockState = CursorLockMode.Locked;
        startGameFeedbacks.PlayFeedbacks();
    }

    public void CreditsButtonPressed()
    {
        Debug.Log("Code pas écrit Bozo");
    }
}
