using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    public bool isPaused { get; private set; }
    [SerializeField] private GameObject pauseCanva;

    private void Start()
    {
        pauseCanva.SetActive(false);
    }

    public void OnPause()
    {
        if (!isPaused)
        {
            isPaused = true;
            pauseCanva.SetActive(isPaused);
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            pauseCanva.SetActive(isPaused);
            Time.timeScale = 1;
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
