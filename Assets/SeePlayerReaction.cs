using DG.Tweening;
using UnityEngine;

public class SeePlayerReaction : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            transform.DOMoveY(transform.position.y + 0.75f, 0.15f).SetEase(Ease.Linear).OnComplete(() =>
            {
                transform.DOMoveY(transform.position.y - 0.75f, 0.15f).SetEase(Ease.Linear).OnComplete(()=>
                {
                    transform.DOMoveY(transform.position.y + 0.75f, 0.15f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        transform.DOMoveY(transform.position.y - 0.75f, 0.15f).SetEase(Ease.Linear);
                    });
                });
            });
        }
    }
}