using TMPro;
using UnityEngine;

public class UITimerScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI timerTextUI;


    private void Update()
    {
        GameManager_Offi.Instance.IncreaseTimer();
        UpdateTimerUI();
    }


    private void UpdateTimerUI()
    {
        float minutes = Mathf.FloorToInt(GameManager_Offi.Instance.Temps / 60);
        float unroundedSeconds = GameManager_Offi.Instance.Temps % 60;
        float seconds = Mathf.Round(unroundedSeconds * 100) / 100;

        timerTextUI.SetText(minutes + ":" + seconds);
    }
}
