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
    [SerializeField] Player player;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void StartBattle()
    {
        StartCoroutine(StartGame());
    }

    public void ReloadBattle()
    {
        SceneManager.LoadScene("ProtoBossBattle");
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
