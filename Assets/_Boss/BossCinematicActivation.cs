using MoreMountains.Feedbacks;
using UnityEngine;

public class BossCinematicActivation : MonoBehaviour
{
    [SerializeField] private MMF_Player cinematic;
    [SerializeField] private MMF_Player shortCinematic;

    void Start()
    {
        if(!GameManager_Offi.Instance.bossCinematicPlayed)
        {
            cinematic.PlayFeedbacks();
            GameManager_Offi.Instance.bossCinematicPlayed = true;
        }
        else
        {
            shortCinematic.PlayFeedbacks();
        }
    }
}
