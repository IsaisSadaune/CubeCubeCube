using TMPro;
using UnityEngine;

public class UITimerScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI timerTextUI;

    [Header("Datas")]
    public float timeElapsed { get; private set; }


    private void Start()
    {
        timeElapsed = 0f;
    }

    private void Update()
    {
        IncreaseTimer();
        UpdateTimerUI();
    }

    private void IncreaseTimer()
    {
        if (Time.timeScale != 0f)
        {
            timeElapsed += Time.deltaTime;
        }
    }

    private void UpdateTimerUI()
    {
        float minutes = Mathf.FloorToInt(timeElapsed / 60);
        float unroundedSeconds = timeElapsed % 60;
        float seconds = Mathf.Round(unroundedSeconds * 100) / 100;

        timerTextUI.SetText(minutes + ":" + seconds);
    }
}
