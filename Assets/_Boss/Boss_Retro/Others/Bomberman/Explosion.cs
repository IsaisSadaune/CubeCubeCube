using MoreMountains.Feedbacks;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    SlabController tile;
    MMF_Player feedback;
    void Awake()
    {
        feedback = GetComponent<MMF_Player>();
        feedback.PlayFeedbacks();
    }
}