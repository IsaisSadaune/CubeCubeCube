using System.Collections;
using DG.Tweening;
using MoreMountains.Feedbacks;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public void Awake()
    {
        transform.DOScale(100, 0.5f);
        StartCoroutine(Dissapearing());
    }

    IEnumerator Dissapearing()
    {
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObject);
    }
}