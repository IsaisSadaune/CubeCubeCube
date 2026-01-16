using DG.Tweening;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform endPosition;
    [SerializeField] private float speed = 3f;
    private void Start()
    {
        transform.DOMove(endPosition.position, speed).OnComplete(() => Destroy(gameObject));
    }
}
