using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using System.Collections;
using UnityEngine;

public class UIRageBar : MonoBehaviour
{
    public MMProgressBar rageBar;
    private MMF_Player barFlickerFbPlayer;

    private float rageMax;
    private float value;
    [MMFInspectorButton("ChangeBarValue")] public bool ChangeBarValueBtn;

    private void Start()
    {
        rageBar = GetComponent<MMProgressBar>();
        barFlickerFbPlayer = GetComponent<MMF_Player>();
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
        yield return new WaitUntil(() => value == rageMax);
        barFlickerFbPlayer.PlayFeedbacks();

        // Mettre le double de la dur�e du Holding pause entre deux swaps d'image en temps
        yield return new WaitForSecondsRealtime(0.50f);
        StartCoroutine(BarFlickerTrigger());
    }
}
