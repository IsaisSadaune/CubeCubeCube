using System.Collections;
using DG.Tweening;
using MoreMountains.Feedbacks;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public void Scaling(int scale)
    {
        transform.DOScale(scale, 0.5f * (scale/100));
        StartCoroutine(Dissapearing());
    }

    IEnumerator Dissapearing()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}