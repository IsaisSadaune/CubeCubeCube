using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRankCalculScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI bossNameText;
    [SerializeField] private TextMeshProUGUI timeText, parryText, healText, lostRageText, rankText, pBText;
    public BossScoreRequirementsScriptable scoreRequirements;
    public Button buttonToSelect;

    private int finalScore;
    public char finalRank { get; private set; }

    private void Start()
    {
        finalScore = 0;
    }

    public void CalculateAndDisplayVictoryDatas(float secondsToBeat, int nbrParryDone, int nbrHealsUsed, float lostRage, int bossnumber)
    {
        finalScore = 0;
        TimeScore(secondsToBeat);
        ParryScore(nbrParryDone);
        PointLoss(nbrHealsUsed, lostRage);

        DetermineRank();

        UpdateText(secondsToBeat, nbrParryDone, nbrHealsUsed, lostRage);
        UpdatePB(bossnumber);
    }


    #region CalculateScore
    void TimeScore(float timeToBeatBoss)
    {
        float timeScore = scoreRequirements.startTimeScore - (scoreRequirements.scoreLossPerSecond * timeToBeatBoss);

        if (timeScore <= 0)
            timeScore = 0;

        finalScore += Mathf.RoundToInt(timeScore);
        //Debug.Log(timeScore);
    }

    void ParryScore(int nbrParryDone)
    {
        if (nbrParryDone > scoreRequirements.maxParryAmount)
            nbrParryDone = scoreRequirements.maxParryAmount;

        finalScore += nbrParryDone * scoreRequirements.pointsPerParry;
        //Debug.Log(finalScore);
    }

    void PointLoss(int nbrHealsUsed, float rageLost)
    {
        finalScore -= nbrHealsUsed * scoreRequirements.pointsLostPerHeal;

        float timesRageLost = rageLost / scoreRequirements.lostRageToTriggerPointLoss;
        finalScore -= (int)timesRageLost * scoreRequirements.pointsLostPerRageLoss;
        //Debug.Log(finalScore);
    }

    void DetermineRank()
    {
        if (finalScore >= scoreRequirements.scoreForS)
            finalRank = 'S';
        else if (finalScore < scoreRequirements.scoreForS && finalScore >= scoreRequirements.scoreForA)
            finalRank = 'A';
        else if (finalScore < scoreRequirements.scoreForA && finalScore >= scoreRequirements.scoreForB)
            finalRank = 'B';
        else if (finalScore < scoreRequirements.scoreForB && finalScore >= scoreRequirements.scoreForC)
            finalRank = 'C';
        else if (finalScore < scoreRequirements.scoreForC)
            finalRank = 'D';
    }
    #endregion

    void UpdateText(float secondsToBeat, int nbrParryDone, int nbrHealUsed, float lostRage)
    {
        bossNameText.SetText(scoreRequirements.bossName);

        float minutes = Mathf.FloorToInt(secondsToBeat / 60);
        float unroundedSeconds = secondsToBeat % 60;
        float seconds = Mathf.Round(unroundedSeconds * 100) / 100;
        timeText.SetText(minutes + ":" + seconds);

        parryText.SetText(nbrParryDone + "/" + scoreRequirements.maxParryAmount);
        healText.SetText(nbrHealUsed.ToString());
        lostRageText.SetText(lostRage.ToString());

        rankText.SetText(finalRank.ToString());

    }

    void UpdatePB(int bossNumber)
    {
        //PersonalBest
        float pbBoss = GameManager_Offi.Instance.GetPBBoss(bossNumber);
        float minutes = Mathf.FloorToInt(pbBoss / 60);
        float unroundedSeconds = pbBoss % 60;
        float seconds = Mathf.Round(unroundedSeconds * 100) / 100;
        pBText.SetText("Personal Best : " + minutes + ":" + seconds);
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