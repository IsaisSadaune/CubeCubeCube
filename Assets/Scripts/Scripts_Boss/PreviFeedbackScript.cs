using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PreviFeedbackScript : MonoBehaviour
{
    [SerializeField] private Color startColor, endColor;
    private Renderer renderer;
    private Vector3 baseScale;
    [SerializeField] private float changeScaleDuration, changeColorDuration, timeBeforeChangingColor, timeBeforeDestroyWhenFinished;

    private void Start()
    {
        baseScale = transform.localScale;
        transform.localScale = new Vector3(0.1f, transform.localScale.y, 0.1f);
        renderer = GetComponent<Renderer>();
        renderer.material.color = startColor;

        StartCoroutine(TriggerFeedbacks());
    }
    private IEnumerator TriggerFeedbacks()
    {
        transform.DOScale(baseScale, changeScaleDuration);
        renderer.material.DOColor(endColor, changeColorDuration);
        yield return new WaitForSeconds(timeBeforeDestroyWhenFinished);
        Destroy(this.gameObject);
    }
}
