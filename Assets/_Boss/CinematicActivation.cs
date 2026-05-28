using MoreMountains.Feedbacks;
using UnityEngine;

public class CinematicActivation : MonoBehaviour
{
    [SerializeField] MMF_Player cinematic;
    private void Start()
    {
        cinematic.PlayFeedbacks();
    }
}
