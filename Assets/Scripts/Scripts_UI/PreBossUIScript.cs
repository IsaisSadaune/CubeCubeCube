using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PreBossUIScript : MonoBehaviour
{
    public PlayerInput input;
    public enum BossSelection { DiceBoss, RetroBoss, Tutorial }
    [SerializeField] BossSelection bossReferenced;

    [Space(10f)]
    public Button buttonToSelect;
    private float recordTempsBoss;
    private char rankBoss;
    private string bossName;
    [SerializeField] private TextMeshProUGUI bossNameText, rankText, highScoreText;
    [SerializeField] private MMF_Player openFeedbacks, closeFeedbacks;

    [ContextMenu("Open the menu")]
    public void OpenMenu()
    {
        input.SwitchCurrentActionMap("UI");
        Debug.Log(input.currentActionMap);
        SearchStatsDependingOnBossNbr();
        UpdateText();
        openFeedbacks.PlayFeedbacks();
        SelectButton();
    }

    void SearchStatsDependingOnBossNbr()
    {
        switch (bossReferenced)
        {
            case BossSelection.DiceBoss:
                bossName = "Dice Boss";
                if (GameManager_Offi.Instance.act >= GameProgression.Boss1Beaten)
                {
                    recordTempsBoss = GameManager_Offi.Instance.recordTempsBoss1;
                    rankBoss = GameManager_Offi.Instance.rankBoss1;
                }
                else
                {
                    recordTempsBoss = 0.00f;
                    rankBoss = 'X';
                }
                break;
                

            case BossSelection.RetroBoss:
                bossName = "Retro Boss";
                if (GameManager_Offi.Instance.act >= GameProgression.Boss2Beaten)
                {
                    recordTempsBoss = GameManager_Offi.Instance.recordTempsBoss2;
                    rankBoss = GameManager_Offi.Instance.rankBoss2;
                }
                else
                {
                    recordTempsBoss = 0.00f;
                    rankBoss = 'X';
                }
                break;



            case BossSelection.Tutorial:
                bossName = "Tutorial";
                break;


            default:
                bossName = "Boss unassigned";
                recordTempsBoss = 0.00f;
                rankBoss = 'X';
                break;
        }
    }

    private void UpdateText()
    {
        if(bossNameText)
            bossNameText.SetText(bossName);
        if(rankText)
            rankText.SetText(rankBoss + "");
        if(highScoreText)
            highScoreText.SetText(recordTempsBoss + "");
    }

    public void CloseMenu()
    {
        input.SwitchCurrentActionMap("Gameplay");
        Debug.Log(input.currentActionMap);
        closeFeedbacks.PlayFeedbacks();
    }

    void SelectButton()
    {
        if (buttonToSelect != null)
            buttonToSelect.Select();
        else
            Debug.Log("Button to select is null");
    }
}
