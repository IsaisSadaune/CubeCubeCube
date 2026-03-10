using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PreviFeedbackScript : MonoBehaviour
{
    [SerializeField] private Color startColor, endColor;
    private Renderer renderer;
    private Vector3 baseScale;
    [SerializeField] private float changeScaleDuration, changeColorDuration, timeBeforeChangingColor;

    private void Start()
    {
        baseScale = transform.localScale;
        transform.localScale = new Vector3(0.1f, transform.localScale.y, 0.1f);
        renderer = GetComponent<Renderer>();
        renderer.material.color = startColor;
    }

    private void ChangeColor()
    {
        renderer.material.DOColor(endColor, changeColorDuration);
    }

    [ContextMenu("Trigger Feedbacks")]
    private void StartTheFeedbacks()
    {
        StartCoroutine(TriggerFeedbacks());
    }

    private IEnumerator TriggerFeedbacks()
    {
        ScaleApparition();
        yield return new WaitForSeconds(timeBeforeChangingColor);
        ChangeColor();
    }

    private void ScaleApparition()
    {
        transform.DOScale(baseScale, changeScaleDuration);
    }
}
