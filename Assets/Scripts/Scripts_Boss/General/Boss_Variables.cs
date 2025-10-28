using UnityEngine;

public class Boss_Variables : MonoBehaviour, IDamageable
{
    [SerializeField] private float MaxHP;
    public float HP { get; private set; }
    public bool isSlimy { get; private set; }
    public bool isDestroying { get; private set; }

    public GameObject detector1;

    public GameObject detector2;

    public void SetSlimy() => isSlimy = true;
    public void StopSlimy() => isSlimy = false;

    public void SetDestroying() => isDestroying = true;
    public void StopDestroying() => isDestroying = false;

    private void Awake()
    {
        HP = MaxHP;
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


    public void TakeDamage(int _dgt)
    {
        Debug.Log("ouch");
        HP -= _dgt;
        if (HP < 0) Die();
    }

    public void Die()
    {
        Debug.Log("mort");
        Destroy(gameObject);
    }
}
