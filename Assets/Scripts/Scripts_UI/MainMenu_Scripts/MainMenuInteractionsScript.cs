using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuInteractionsScript : MonoBehaviour
{
    [SerializeField] MMF_Player startGameFeedbacks;
    bool GameStarted;
    [SerializeField] Button buttonToSelect;

    [Header("Credits Screen")]
    public GameObject creditsScreen;
    [SerializeField] MMF_Player creditsPlayer;

    [Header("Option Screen")]
    public GameObject optionScreen;
    public GameObject mainMenuScreen;
    public Button buttonToSelectOptionOpen, buttonToSelectOptionClose;


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

    public void SelectPlayButton()
    {
        buttonToSelect.Select();
    }

    public void CreditsButtonPressed()
    {
        creditsScreen.SetActive(true);
        creditsPlayer.PlayFeedbacks();
    }

    public void ButtonSelectMainMenu()
    {
        buttonToSelect.Select();
    }

    public void OptionButtonMainMenu()
    {
        optionScreen.SetActive(true);
        mainMenuScreen.SetActive(false);
        buttonToSelectOptionOpen.Select();
    }

    public void BackButtonOptions()
    {
        optionScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
        buttonToSelectOptionClose.Select();
    }
}
