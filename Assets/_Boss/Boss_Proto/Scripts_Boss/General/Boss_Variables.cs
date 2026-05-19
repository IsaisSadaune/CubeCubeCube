using DG.Tweening;
using MoreMountains.Feedbacks;
using UnityEngine;

public class Boss_Variables : MonoBehaviour, IDamageable
{
    [SerializeField] private GameObject visual;

    [SerializeField] private float MaxHP;
    public float HP { get; private set; }
    public bool isDestroying { get; private set; }
    public bool isHardDestroying { get; private set; }
    private RetroBoss retroBoss;

    public MMF_Player damageFeedback;
    public MMF_Player deathFeedback;

    public GameObject detector1;
    public GameObject detector2;

    public bool IsDead() => HP <= 0;

    public void SetDestroying() => isDestroying = true;
    public void StopDestroying() => isDestroying = false;

    public void SetHardDestroying() => isHardDestroying = true;
    public void StopHardDestroying() => isHardDestroying = false;

    protected bool isDying = false;

    private void Awake()
    {
        HP = MaxHP;
        retroBoss = GetComponent<RetroBoss>();
    }

    public void ResetDetectors()
    {
        detector1.SetActive(false);
        detector1.SetActive(true);
        detector2.SetActive(false);
        detector2.SetActive(true);
    }

    //feedback boss
    [ContextMenu("damage")]
    public void TakeDamageDebug() => TakeDamage(100);



    //public void OnTriggerEnter(Collider other)
    //{
    //    if(other.TryGetComponent<IDamageable>(out IDamageable dmged))
    //    {
    //        Debug.Log(other.gameObject + " took dmg");
    //        dmged.TakeDamage(5);
    //    }
    //}
    public void TakeDamage(int _dgt)
    {
        //Debug.Log("ouch");
        HP -= _dgt;
        if (HP <= 0) Die();
        else FeedBackDMG();
    }
    public void Die()
    {
        foreach(GameObject go in retroBoss.clones)
        {
            go.transform.DOScale(0, 0.2f).OnComplete(()=> Destroy(go));
        }
        //Debug.Log("mort");
        FeedBackMort();
    }
        
    public void FeedBackDMG()
    {
        damageFeedback.PlayFeedbacks();
        // Vector3 x = visual.transform.localScale;
        // visual.transform.DOScale(x * 1.25f, 0.12f).SetEase(Ease.InOutBounce)
        //     .OnComplete(() =>
        //     visual.transform.DOScale(x, 0.12f).SetEase(Ease.InOutBounce));
    }
    public virtual void FeedBackMort()
    {
        if (!isDying)
        {
            isDying = true;
            if (deathFeedback != null)
                deathFeedback.PlayFeedbacks();
            else
            {
                visual.transform.DOScale(Vector3.zero, 1f)
                    .OnComplete(() => Destroy(gameObject));
            }
        }
    }
}
