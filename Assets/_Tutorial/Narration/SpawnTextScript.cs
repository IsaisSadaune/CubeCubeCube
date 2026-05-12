using UnityEngine;
using MoreMountains.Feedbacks;

public class SpawnTextScript : MonoBehaviour
{
    [SerializeField] private MMF_Player revealAnim;
    bool textRevealed;

    private void OnTriggerEnter(Collider other)
    {
        if (!textRevealed)
        {
            textRevealed = true;
            revealAnim.PlayFeedbacks();
        }
    }
}
