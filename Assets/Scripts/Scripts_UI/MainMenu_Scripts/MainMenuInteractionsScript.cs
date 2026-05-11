using MoreMountains.Feedbacks;
using UnityEngine;

public class MainMenuInteractionsScript : MonoBehaviour
{
    [SerializeField] MMF_Player startGameFeedbacks;
    bool GameStarted;

    [Header("Credits Screen")]
    public GameObject creditsScreen;
    [SerializeField] MMF_Player creditsPlayer;


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
        //Cursor.lockState = CursorLockMode.Locked;
        startGameFeedbacks.PlayFeedbacks();
    }

    public void CreditsButtonPressed()
    {
        creditsScreen.SetActive(true);
        creditsPlayer.PlayFeedbacks();
    }
}
