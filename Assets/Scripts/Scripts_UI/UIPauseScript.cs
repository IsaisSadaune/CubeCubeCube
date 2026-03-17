using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIPauseScript : MonoBehaviour
{
    [SerializeField] private MMF_Player pauseFeedbacks;
    [SerializeField] private GameObject PauseCanva;
    [SerializeField] private Button buttonToSelect;
    private bool paused;

    public void PauseGame()
    {
        if (!paused)
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
        SceneManager.LoadScene(currentScene.name);
    }

    public void QuitPauseButtonPressed()
    {
        // Revenir au HUB si le joueur est dans un boss
        Debug.Log("Quit still not implemented");
    }
    #endregion
}
