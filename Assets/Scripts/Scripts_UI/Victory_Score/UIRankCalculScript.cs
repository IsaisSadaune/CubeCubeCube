using TMPro;
using UnityEngine;

public class UIRankCalculScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI parryText, healText, lostRageText, rankText;
    public BossScoreRequirementsScriptable scoreRequirements;

    private int finalScore;

    private void Start()
    {
        finalScore = 0;
    }

    public void CalculateAndDisplayVictoryDatas(float secondsToBeat, int nbrParryDone, int nbrHealsUsed, float lostRage)
    {
        TimeScore(secondsToBeat);
        ParryScore(nbrParryDone);
        PointLoss(nbrHealsUsed, lostRage);

        DetermineRank();
    }

    #region CalculateScore
    void TimeScore(float timeToBeatBoss)
    {
        float timeScore = scoreRequirements.startTimeScore - (scoreRequirements.scoreLossPerSecond * timeToBeatBoss);

        if (timeScore <= 0) 
            timeScore = 0;

        finalScore += Mathf.RoundToInt(timeScore);
    }

    void ParryScore(int nbrParryDone)
    {
        if(nbrParryDone > scoreRequirements.maxParryAmount)
            nbrParryDone = scoreRequirements.maxParryAmount;

        finalScore += nbrParryDone * scoreRequirements.pointsPerParry;
    }

    void PointLoss(int nbrHealsUsed, float rageLost)
    {
        finalScore -= nbrHealsUsed * scoreRequirements.pointsLostPerHeal;

        float timesRageLost = rageLost / scoreRequirements.lostRageToTriggerPointLoss;
        finalScore -= (int)timesRageLost * scoreRequirements.pointsLostPerRageLoss;
    }
    #endregion

    void DetermineRank()
    {
        if(finalScore >= scoreRequirements.scoreForS)
            return;
        else if (finalScore < scoreRequirements.scoreForS && finalScore >= scoreRequirements.scoreForA)
            return;
        else if (finalScore < scoreRequirements.scoreForA && finalScore >= scoreRequirements.scoreForB)
            return;
        else if (finalScore < scoreRequirements.scoreForB && finalScore >= scoreRequirements.scoreForC)
            return;
        else if (finalScore < scoreRequirements.scoreForC)
            return;
    }
}
