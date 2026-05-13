using System;

public class HP_GlitchTuto : Boss_Variables
{
    public event Action GlitchDestroyed;

    public override void FeedBackMort()
    {
        if (!isDying)
        {
            base.FeedBackMort();
            GlitchDestroyed?.Invoke();
        }
    }
}
