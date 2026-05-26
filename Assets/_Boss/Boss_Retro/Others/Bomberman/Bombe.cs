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

    public void Explosion()
    {
        GameObject explosion = Instantiate(prefabExplosion, transform.position, Quaternion.Euler(new Vector3 (-90,0,0)));
        explosion.GetComponent<Explosion>().Scaling(powerLevel);
        transform.DOScale(0, 0.3f).OnComplete(()=> Destroy(gameObject));
    }
}
