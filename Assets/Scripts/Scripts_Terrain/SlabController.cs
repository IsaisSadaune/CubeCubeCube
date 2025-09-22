using UnityEngine;
using DG.Tweening;
using System.Collections;

public class SlabController : MonoBehaviour
{
    private Vector3 scale;
    private void Start()
    {
        scale = transform.localScale;
    }

    public void Disparition()
    {
        transform.DOScale(Vector3.zero, 0.5f);
    }

    public void Apparition()
    {
        transform.DOScale(scale, 0.5f);
    }
}
