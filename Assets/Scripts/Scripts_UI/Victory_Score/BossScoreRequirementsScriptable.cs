using UnityEngine;

[CreateAssetMenu(fileName = "BossScoreRequirementsScriptableObject", menuName = "Scriptable Objects/BossScoreRequirementsScriptableObject")]
public class BossScoreRequirementsScriptable : ScriptableObject
{
    [Header("Boss informations")]
    public string bossName;

    [Header("Calcul du score")]
    public float startTimeScore;
    public float scoreLossPerSecond;
    [Space(10)]
    public int maxParryAmount;
    public int pointsPerParry;
    [Space(10)]
    public int pointsLostPerHeal;
    [Space(10)]
    public float lostRageToTriggerPointLoss;
    public int pointsLostPerRageLoss;
    [Space(10)]
    public int scoreForS;
    public int scoreForA, scoreForB, scoreForC;
}
