using DG.Tweening;
using UnityEngine;

public class SeePlayerReaction : MonoBehaviour
{
    private Sequence sequence;
    private Vector3 OGPos;


    private void Start()
    {
        OGPos = transform.position;
    }




    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sequence.Kill();
            sequence = DOTween.Sequence();
            sequence.Append(transform.DOMoveY(OGPos.y + 0.75f, 0.15f).SetEase(Ease.Linear));
            sequence.Append(transform.DOMoveY(OGPos.y, 0.15f).SetEase(Ease.Linear));
            sequence.Append(transform.DOMoveY(OGPos.y + 0.75f, 0.15f).SetEase(Ease.Linear));
            sequence.Append(transform.DOMoveY(OGPos.y, 0.15f).SetEase(Ease.Linear));
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sequence.Kill();
            sequence = DOTween.Sequence();
            sequence.Append(transform.DOMoveY(OGPos.y, 0.15f));
        }
    }
}