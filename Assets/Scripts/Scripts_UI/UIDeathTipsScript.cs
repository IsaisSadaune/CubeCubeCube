using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

public class UIDeathTipsScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI tipsText;
    [SerializeField] private GameObject mainVolume, deathVolume;

    [Header("Tips à afficher")]
    [SerializeField] private string[] availableTips;
    private string tipsToDisplay;

    private void Start()
    {
        mainVolume.SetActive(true);
        deathVolume.SetActive(false);
    }

    [ContextMenu("Trigger Death")]
    public void OnPlayerDeath()
    {
        mainVolume.SetActive(false);
        deathVolume.SetActive(true);
        DisplayTips();
    }

    private void DisplayTips()
    {
        int tableLength = availableTips.Length;
        tipsToDisplay = availableTips[Random.Range(0, tableLength)];

        tipsText.SetText("Tips : " + tipsToDisplay);
    }
}
