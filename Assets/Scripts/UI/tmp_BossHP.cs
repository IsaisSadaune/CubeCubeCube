using UnityEngine;
using UnityEngine.UI;

public class tmp_BossHP : MonoBehaviour
{
    [SerializeField] private Image bossBar;


    /// <summary>
    /// percentage is between 0 and 1
    /// </summary>
    /// <param name="percentageHP"></param>
    public void UpdateBossHP(float percentageHP)
    {
        bossBar.fillAmount = percentageHP;
    }
}
