using MoreMountains.Feedbacks;
using TMPro;
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
    public TextMeshProUGUI deleteButtonText;
    private bool deleteButtonPressedOnce;

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

        if (deleteButtonPressedOnce)
            ResetDeletionConfirmation();
    }

    private void ResetDeletionConfirmation()
    {
        deleteButtonPressedOnce = false;
        deleteButtonText.SetText("Delete save");
    }

    public void DeleteButtonPressed()
    {
        if (deleteButtonPressedOnce)
            DeleteConfirmed();
        else
        {
            deleteButtonPressedOnce = true;
            deleteButtonText.SetText("Confirm deletion ?");
        }
    }
    private void DeleteConfirmed()
    {
        Debug.Log("Save Deleted");
        GameManager_Offi.Instance.ResetSave();
        deleteButtonText.SetText("Save deleted !");
    }
}
