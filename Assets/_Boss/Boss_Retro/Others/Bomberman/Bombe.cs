using DG.Tweening;
using MoreMountains.Feedbacks;
using UnityEngine;

public class Bombe : MonoBehaviour
{
    [SerializeField] int powerLevel;
    [SerializeField] GameObject prefabExplosion;
    [SerializeField] MMF_Player explose;

    void Start()
    {
        explose = GetComponent<MMF_Player>();
        explose.PlayFeedbacks();
    }

}
