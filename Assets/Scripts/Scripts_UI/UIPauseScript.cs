using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIPauseScript : MonoBehaviour
{
    [SerializeField] private MMF_Player pauseFeedbacks;
    [SerializeField] private GameObject PauseCanva;
    [SerializeField] private Button buttonToSelect;

    [ContextMenu("Pause the game")]
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseFeedbacks.PlayFeedbacks();
    }

    [ContextMenu("Resume the game")]
    public void ResumeGame()
    {
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
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void QuitPauseButtonPressed()
    {
        // Revenir au HUB si le joueur est dans un boss
    }
    #endregion
}
