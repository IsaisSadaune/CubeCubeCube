using System;
using UnityEngine;

public class HP_GlitchTuto : Boss_Variables
{
    public event Action GlitchDestroyed;

    public override void FeedBackMort()
    {
        base.FeedBackMort();
        GlitchDestroyed?.Invoke();
    }
}
