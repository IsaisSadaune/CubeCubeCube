using UnityEngine;
using MoreMountains.Tools;

public class UIRageBar : MonoBehaviour
{
    public MMProgressBar rageBar;

    [Range(0f, 100f)] public float value;
    [MMInspectorButton("ChangeBarValue")] public bool ChangeBarValueBtn;

    void ChangeBarValue()
    {
        rageBar.UpdateBar(value, 0f, 100f);
    }
}
