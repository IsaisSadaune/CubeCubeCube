using MoreMountains.Feedbacks;
using System.Collections;
using UnityEngine;

public class HubCinematicActivation : MonoBehaviour
{
    public MMF_Player cinematic;
    private void Start()
    {
        if(!GameManager_Offi.Instance.hubCinematicPlayed)
        {
            GetComponent<MMF_Player>();
            cinematic.PlayFeedbacks();
            GameManager_Offi.Instance.hubCinematicPlayed = true;
        }
    }
}
