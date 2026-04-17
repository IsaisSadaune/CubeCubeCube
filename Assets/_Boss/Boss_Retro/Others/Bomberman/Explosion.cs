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
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            Debug.Log("Collision with ground");
            tile = other.transform.parent.GetComponent<SlabController>();
            tile.Destroyed();
        }
    }
}
