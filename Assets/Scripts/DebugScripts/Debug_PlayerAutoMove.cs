using DG.Tweening;
using UnityEngine;
using System.Collections.Generic;

public class Debug_PlayerAutoMove : MonoBehaviour
{
    [SerializeField] private List<Transform> pos;
    Sequence s;
    private Transform t;
    private void Awake()
    {
        t = transform;
    }
    private void Start()
    {
        s = DOTween.Sequence();
        foreach (Transform t in pos)
        {
            s.Append(transform.DOMove(t.position, 1f));
        }
        s.Append(transform.DOMove(t.position, 1f));
        s.SetLoops(-1);
    }
}
