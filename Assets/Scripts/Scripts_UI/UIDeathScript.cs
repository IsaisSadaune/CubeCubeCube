using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDeathScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI tipsText;
    [SerializeField] private GameObject mainVolume, deathVolume;
    [SerializeField] private Button buttonToSelect;
    [Header("Tips à afficher")]
    [SerializeField] private string[] availableTips;
    private string tipsToDisplay;

    private void Start()
    {
        mainVolume.SetActive(true);
        deathVolume.SetActive(false);
    }

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

    #region Death buttons scripts
    public void RestartButton()
    {
        Debug.Log("Restart");
    }

    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void SelectRestartButton()
    {
        buttonToSelect.Select();
    }
    #endregion
}
