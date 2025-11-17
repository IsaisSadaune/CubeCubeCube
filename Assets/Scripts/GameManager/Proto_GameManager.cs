using UnityEngine;
using UnityEngine.SceneManagement;

public class Proto_GameManager : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject UI_Reload;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void StartBattle()
    {
        Time.timeScale = 1;
        UI.SetActive(false);
    }

    public void ReloadBattle()
    {
        SceneManager.LoadScene("ProtoBossBattle");
    }
}
