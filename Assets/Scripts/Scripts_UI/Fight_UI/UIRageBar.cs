using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using System.Collections;
using UnityEngine;

public class UIRageBar : MonoBehaviour
{
    public MMProgressBar rageBar;
    [SerializeField] private MMF_Player barFlickerFbPlayer;

    private float rageMax;
    private float value;

    private void Start()
    {
        barFlickerFbPlayer.PlayFeedbacks();
        StartCoroutine(BarFlickerTrigger());
        value = 0;
        ChangeBarValue(value);
    }


    public void SetRageMax(float maxRage)
    {
        this.rageMax = maxRage;
    }

    public void ChangeBarValue(float startValue)
    {
        rageBar.UpdateBar(startValue, 0f, rageMax);
    }

    public void IncreaseRageBar(int valueToAdd)
    {
        value = Mathf.Min(value + valueToAdd, rageMax);

        ChangeBarValue(value);
    }

    public void DecreaseBarValue(int valueToPull)
    {
        value = Mathf.Max(0, value - valueToPull);

        ChangeBarValue(value);
    }

    IEnumerator BarFlickerTrigger()
    {
        yield return new WaitForSeconds(0.50f);
        yield return new WaitUntil(() => value == rageMax);
        barFlickerFbPlayer.PlayFeedbacks();
        StartCoroutine(BarFlickerTrigger());
    }
}
