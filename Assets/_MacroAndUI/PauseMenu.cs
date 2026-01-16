using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Player player;
    public bool isPaused { get; private set; }
    [SerializeField] private GameObject pauseCanva;
    [SerializeField] private GameObject startCanva;

    [SerializeField] private Button firstSelectedButton;
    [SerializeField] private Button pauseMenuFirstSelectedButton;

    [SerializeField] private Input input;

    private void Start()
    {
        isPaused = false;
        pauseCanva.SetActive(false);
    }

    private void Update()
    {
        if (pauseCanva.gameObject.activeSelf || startCanva.gameObject.activeSelf || player.isDead)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            OnPause();
        }
    }

    public void OnPause()
    {
        if (!isPaused && !startCanva.activeSelf)
        {
            isPaused = true;
            pauseCanva.SetActive(isPaused);
            EventSystem.current.SetSelectedGameObject(pauseMenuFirstSelectedButton.gameObject);
            Time.timeScale = 0;
            player.playerInput.SwitchCurrentActionMap("UI");
        }
        else if (!startCanva.activeSelf && isPaused)
        {
            StartCoroutine(ExitPause());
        }
    }

    IEnumerator ExitPause()
    {
        isPaused = false;
        pauseCanva.SetActive(isPaused);

        EventSystem.current.SetSelectedGameObject(firstSelectedButton.gameObject);


        Time.timeScale = 1;
        yield return null;
        player.playerInput.SwitchCurrentActionMap("Gameplay");
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
