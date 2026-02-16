using MoreMountains.Tools;
using UnityEngine;

public class UIRageBar : MonoBehaviour
{
    public MMProgressBar rageBar;

    [Range(0f, 100f)] public float value;
    [MMInspectorButton("ChangeBarValue")] public bool ChangeBarValueBtn;

    private void Start()
    {
        value = 0f;
        ChangeBarValue();
    }

    void ChangeBarValue()
    {
        rageBar.UpdateBar(value, 0f, 100f);
    }

    public void IncreaseRageBar(int valueToAdd)
    {
        value += valueToAdd;
        ChangeBarValue();
    }

    public void DecreaseBarValue(int valueToPull)
    {
        value -= valueToPull;
        ChangeBarValue();
    }

}
