using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRankCalculScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI bossNameText;
    [SerializeField] private TextMeshProUGUI timeText, rankText, pBText;
    public BossScoreRequirementsScriptable scoreRequirements;
    public Button buttonToSelect;

    public char finalRank { get; private set; }

    public void CalculateAndDisplayVictoryDatas(float secondsToBeat, int nbrParryDone, int nbrHealsUsed, float lostRage, int bossnumber)
    {
        AudioManager.Instance.PauseMusic();
        DetermineRank(secondsToBeat);

        UpdateText(secondsToBeat);
        UpdatePB(bossnumber);
    }


    #region CalculateScore

    void DetermineRank(float secondsToBeat)
    {
        if (secondsToBeat <= scoreRequirements.timeForS)
        { 
            finalRank = 'S';
            AudioManager.Instance.PlaySound("S Rank");
        }
        else if (secondsToBeat > scoreRequirements.timeForS && secondsToBeat <= scoreRequirements.timeForA)
        {
            finalRank = 'A';
            AudioManager.Instance.PlaySound("A Rank");
        }
        else if (secondsToBeat > scoreRequirements.timeForA && secondsToBeat <= scoreRequirements.timeForB)
        {
            finalRank = 'B';
            AudioManager.Instance.PlaySound("B Rank");
        }
        else if (secondsToBeat > scoreRequirements.timeForB && secondsToBeat <= scoreRequirements.timeForC)
        {
            finalRank = 'C';
            AudioManager.Instance.PlaySound("C Rank");
        }
        else if (secondsToBeat > scoreRequirements.timeForC)
        {
            finalRank = 'D';
            AudioManager.Instance.PlaySound("D Rank");
        }
    }
    #endregion

    void UpdateText(float secondsToBeat)
    {
        bossNameText.SetText(scoreRequirements.bossName);

        float seconds = Mathf.Round(secondsToBeat * 100) / 100;
        timeText.SetText(seconds.ToString("F2").Replace(',', '.') + " s");

        rankText.SetText(finalRank.ToString());
    }

    void UpdatePB(int bossNumber)
    {
        //PersonalBest
        float pbBoss = GameManager_Offi.Instance.GetPBBoss(bossNumber);
        float seconds = Mathf.Round(pbBoss * 100) / 100;

        pBText.SetText("Personal Best : " + seconds.ToString("F2").Replace(',', '.'));
    }

    #region Buttons
    public void SelectContinueButton()
    {
        if (buttonToSelect != null)
            buttonToSelect.Select();
        else
            Debug.Log("Button to select is null");
    }
    #endregion
}