using MoreMountains.Feedbacks;
using System.Collections;
using UnityEngine;

public class HubCinematicActivation : MonoBehaviour
{
    public MMF_Player cinematic;
    [SerializeField] private MMF_Player finalCinematic;
    private void Start()
    {
        if(!GameManager_Offi.Instance.hubCinematicPlayed 
            && GameManager_Offi.Instance.act == GameProgression.Boss1Beaten)
        {
            cinematic.PlayFeedbacks();
            GameManager_Offi.Instance.hubCinematicPlayed = true;
        }
        else
        {
            if(!GameManager_Offi.Instance.finalCinematicPlayed && 
                GameManager_Offi.Instance.act == GameProgression.Boss2Beaten)
            {
                finalCinematic.PlayFeedbacks();
                GameManager_Offi.Instance.finalCinematicPlayed = true;
            }
        }
    }
}
