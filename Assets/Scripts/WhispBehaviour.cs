using DG.Tweening;
using UnityEngine;
using System.Collections;

public class WhispBehaviour : MonoBehaviour
{
    public float TimeActive;
    public Ease easeWhisp;
    private void Start()
    {
        if (TimeActive <= 0) TimeActive = 1f;
    }

    private IEnumerator TimeAlive()
    {
        yield return new WaitForSeconds(TimeActive);
        F_DestroyObject();
    }
    private void F_DestroyObject()
    {
        Destroy(gameObject);
    }
    public void F_SpawnObject()
    {
        Debug.Log(easeWhisp);
        transform.DOScaleX(15f, 1f).SetEase(easeWhisp);
        StartCoroutine(TimeAlive());
    }
}
