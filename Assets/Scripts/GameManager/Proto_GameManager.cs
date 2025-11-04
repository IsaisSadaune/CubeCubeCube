using UnityEngine;
using UnityEngine.Rendering;

public class Proto_GameManager : MonoBehaviour
{
    [SerializeField] private GameObject UI;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void StartBattle()
    {
        Time.timeScale = 1;
        UI.SetActive(false);
    }
}
