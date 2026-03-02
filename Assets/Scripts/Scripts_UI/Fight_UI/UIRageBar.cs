using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using System.Collections;
using UnityEngine;

public class UIRageBar : MonoBehaviour
{
    private MMProgressBar rageBar;
    private MMF_Player barFlickerFbPlayer;

    public float rageMax;
    public float value;
    [MMFInspectorButton("ChangeBarValue")] public bool ChangeBarValueBtn;

    private void Start()
    {
        rageBar = GetComponent<MMProgressBar>();
        barFlickerFbPlayer = GetComponent<MMF_Player>();
        StartCoroutine(BarFlickerTrigger());
    }

    public void ChangeBarValue(float startValue)
    {
        rageBar.UpdateBar(startValue, 0f, rageMax);
    }

    public void IncreaseRageBar(int valueToAdd)
    {
        if ((value += valueToAdd) > rageMax)
            value = rageMax;
        else
            value += valueToAdd;

        ChangeBarValue(value);
    }

    public void DecreaseBarValue(int valueToPull)
    {
        if ((value -= valueToPull) < 0)
            value = 0;
        else
            value -= valueToPull;

        ChangeBarValue(value);
    }

    IEnumerator BarFlickerTrigger()
    {
        yield return new WaitUntil(() => value == rageMax);
        barFlickerFbPlayer.PlayFeedbacks();

        // Mettre le double de la durée du Holding pause entre deux swaps d'image en temps
        yield return new WaitForSecondsRealtime(0.50f);
        StartCoroutine(BarFlickerTrigger());
    }
}
