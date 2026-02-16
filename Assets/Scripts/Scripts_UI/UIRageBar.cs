using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using System.Collections;
using UnityEngine;

public class UIRageBar : MonoBehaviour
{
    public MMProgressBar rageBar;

    [Range(0f, 100f)] public float value;
    [MMInspectorButton("ChangeBarValue")] public bool ChangeBarValueBtn;

    [SerializeField] private MMF_Player barFlickerFbPlayer;

    private void Start()
    {
        barFlickerFbPlayer = GetComponent<MMF_Player>();
        ChangeBarValue();
        StartCoroutine(BarFlickerTrigger());
    }

    void ChangeBarValue()
    {
        rageBar.UpdateBar(value, 0f, 100f);
    }

    public void IncreaseRageBar(int valueToAdd)
    {
        if ((value += valueToAdd) > 100)
            value = 100;
        else
            value += valueToAdd;

        ChangeBarValue();
    }

    public void DecreaseBarValue(int valueToPull)
    {
        if ((value += valueToPull) < 0)
            value = 0;
        else
            value -= valueToPull;

        ChangeBarValue();
    }

    IEnumerator BarFlickerTrigger()
    {
        yield return new WaitUntil(() => value == 100f);
        barFlickerFbPlayer.PlayFeedbacks();

        // Mettre le double de la durée du Holding pause entre deux swaps d'image en temps
        yield return new WaitForSecondsRealtime(0.50f);
        StartCoroutine(BarFlickerTrigger());
    }
}
