using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Proto_GameManager : MonoBehaviour
{

    [SerializeField] private GameObject UI_Panel;
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject UI_Reload;
    [field: SerializeField] public Player player { get; private set; }

    private static Proto_GameManager gameManager;
    public static Proto_GameManager GameManager => gameManager;

    private void Awake()
    {
        if(gameManager != null && gameManager != this)
        {
            Destroy(gameObject);
        }
        gameManager = this;
        DontDestroyOnLoad(gameObject);

        Time.timeScale = 0;
    }

    public void StartBattle()
    {
        StartCoroutine(StartGame());
    }

    public void ReloadBattle()
    {
        var actualScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(actualScene.name);
    }

    IEnumerator StartGame()
    {
        
        EventSystem.current.SetSelectedGameObject(UI_Reload);
        Time.timeScale = 1;
        yield return null;
        UI_Panel.SetActive(false);
        player.playerInput.SwitchCurrentActionMap("Gameplay");

    }
}
