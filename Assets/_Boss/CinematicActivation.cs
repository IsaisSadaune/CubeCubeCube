using MoreMountains.Feedbacks;
using System.Collections;
using UnityEngine;

public class CinematicActivation : MonoBehaviour
{
    [SerializeField] MMF_Player cinematic;
    private void Start()
    {
        cinematic.PlayFeedbacks();
    }
}
