using TMPro;
using UnityEngine;

public class UIDeathTipsScript : MonoBehaviour
{
    private string tipsToDisplay;
    public string[] availableTips;

    private TextMeshProUGUI tipsText;

    private void Start()
    {
        tipsText = GetComponent<TextMeshProUGUI>();
        DisplayTips();
    }

    public void DisplayTips()
    {
        int tableLength = availableTips.Length;
        tipsToDisplay = availableTips[Random.Range(0, tableLength)];

        tipsText.SetText("Tips : " + tipsToDisplay);
    }
}
