using System.Collections;
using MoreMountains.Feedbacks;
using UnityEngine;

public class GlitchEvent : MonoBehaviour
{
    public MMF_Player[] glitchs;
    private float timeBeforeNextEvent;

    public void StartGlitchEvents()
    {
        StartCoroutine(GlitchEvents());
    }

    IEnumerator GlitchEvents()
    {
        timeBeforeNextEvent = Random.Range(3f, 7f);
        int rdm = Random.Range(0, glitchs.Length);
        MMF_Player glitchToPlay = glitchs[rdm];
        yield return new WaitForSeconds(timeBeforeNextEvent);
        glitchToPlay.PlayFeedbacks();
        StartGlitchEvents();
    }
}
