using TMPro;
using UnityEngine;

public class UITimerScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI timerTextUI;
    private float seconds;

    private void Start()
    {
        SetTimerTo0();
    }

    public void SetTimerTo0()
    {
        GameManager_Offi.Instance.ResetStats();
        seconds = 0f;
    }

    private void Update()
    {
        GameManager_Offi.Instance.IncreaseTimer();
        UpdateTimerUI();
    }


    private void UpdateTimerUI()
    {
        seconds = Mathf.Round(GameManager_Offi.Instance.Temps * 100) / 100;

        timerTextUI.SetText(seconds.ToString("F2").Replace(',', '.'));
    }
}
