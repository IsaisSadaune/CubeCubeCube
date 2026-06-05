using System.Collections;
using DG.Tweening;
using MoreMountains.Feedbacks;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public void Awake()
    {
        transform.DOScale(100, 0.3f).SetEase(Ease.OutCubic);
        StartCoroutine(Dissapearing());
    }

    IEnumerator Dissapearing()
    {
        yield return new WaitForSeconds(0.65f);
        transform.DOScale(0, 0.1f)
            .SetEase(Ease.InCubic)
            .OnComplete( () => Destroy(gameObject)
            );
       
    }
}