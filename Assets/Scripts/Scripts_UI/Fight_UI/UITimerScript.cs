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
        float seconds = Mathf.Round(GameManager_Offi.Instance.Temps * 100) / 100;

        timerTextUI.SetText(seconds.ToString("F2").Replace(',', '.'));
    }
}
