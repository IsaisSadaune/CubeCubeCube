using DG.Tweening;
using UnityEngine;

public class Shockwave : MonoBehaviour
{

    [SerializeField] private Transform stop;
    [SerializeField] private float timeToStop;
    private void Start()
    {
        transform.DOMove(stop.position, timeToStop)
            .OnComplete(() => Destroy(transform.parent.gameObject));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerHitbox"))
        {
            other.transform.parent.GetComponent<Player>().TakeDamage(1);
        }
    }
}
