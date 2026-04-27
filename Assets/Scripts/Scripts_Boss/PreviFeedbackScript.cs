using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PreviFeedbackScript : MonoBehaviour
{
    [SerializeField] private Color startColor, endColor;
    private Renderer rend;
    private Vector3 baseScale;
    [SerializeField] private float changeScaleDuration, changeColorDuration, timeBeforeDestroy;

    private Coroutine c;

    public void SetFeedback(float ScaleDuration=1.5f, float ColorTime=1.75f, float TimeBeforeDestroy=2.5f)
    {
        changeScaleDuration = ScaleDuration;
        changeColorDuration = ColorTime;
        timeBeforeDestroy = TimeBeforeDestroy;
    }


    private void OnEnable()
    {
        baseScale = transform.localScale;
        transform.localScale = new Vector3(0.1f, transform.localScale.y, 0.1f);
        rend = GetComponent<Renderer>();
        rend.material.color = startColor;
        c = StartCoroutine(TriggerFeedbacks());
    }

    private IEnumerator TriggerFeedbacks()
    {
        transform.DOScale(baseScale, changeScaleDuration);
        rend.material.DOColor(endColor, changeColorDuration);
        yield return new WaitForSeconds(timeBeforeDestroy);
        gameObject.SetActive(false);
    }

    public void HardStop()
    {
        if(c!=null)
            StopCoroutine(c);
        transform.localScale = baseScale;
        gameObject.SetActive(false);
    }
}
