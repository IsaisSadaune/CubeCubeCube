using UnityEngine;

[CreateAssetMenu(fileName = "BossScoreRequirementsScriptableObject", menuName = "Scriptable Objects/BossScoreRequirementsScriptableObject")]
public class BossScoreRequirementsScriptable : ScriptableObject
{
    [Header("Boss informations")]
    public string bossName;

    [Header("Time required to be under for rank")]
    public float timeForS;
    public float timeForA, timeForB, timeForC;
}
