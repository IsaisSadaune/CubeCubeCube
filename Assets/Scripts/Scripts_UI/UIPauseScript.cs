using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPauseScript : MonoBehaviour
{
    [SerializeField] private MMF_Player pauseFeedbacks;
    [SerializeField] private GameObject PauseCanva;
    [SerializeField] private Button buttonToSelect, optionButtons, buttonToSelectInOptions;
    [SerializeField] private Player player;
    [SerializeField] private GameObject OptionCanvas;
    private bool paused;

    public void PauseGame()
    {
        if (!paused && !player.isDead)
        {
            paused = true;
            Time.timeScale = 0f;
            pauseFeedbacks.PlayFeedbacks();
        }
        else
            ResumeGame();
    }

    public void ResumeGame()
    {
        paused = false;
        Time.timeScale = 1f;
        PauseCanva.SetActive(false);
    }

    #region Buttons
    public void SelectFirstButton()
    {
        buttonToSelect.Select();
    }
    public void RestartButtonPressed()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        GameManager_Offi.Instance.LoadCoroutineScene(currentScene.name);
    }

    public void OptionButtonPressed()
    {
        PauseCanva.SetActive(false);
        OptionCanvas.SetActive(true);
        buttonToSelectInOptions.Select();
    }
    public void QuitOption()
    {
        OptionCanvas.SetActive(false);
        PauseCanva.SetActive(true);
        optionButtons.Select();
    }
    #endregion
}