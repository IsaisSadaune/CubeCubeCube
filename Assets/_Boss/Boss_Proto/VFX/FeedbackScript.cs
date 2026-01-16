using DG.Tweening;
using UnityEngine;

public class FeedbackScript : MonoBehaviour
{
    private Tween t;
    private Vector3 scale;
    private void Awake()
    {
        scale = transform.localScale;
    }
    private void OnEnable()
    {
        t = transform.DOPunchScale(Vector3.one, 0.25f).SetLoops(-1);
    }
    private void OnDisable()
    {
        t.Complete();
        t.Kill();
        transform.localScale = scale;
    }
}
