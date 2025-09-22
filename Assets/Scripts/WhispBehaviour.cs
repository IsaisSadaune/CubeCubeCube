using DG.Tweening;
using UnityEngine;
using System.Collections;

public class WhispBehaviour : MonoBehaviour
{
    public float TimeActive;

    private void Start()
    {
        if (TimeActive <= 0) TimeActive = 1f;
        F_SpawnObject();
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
    private void F_SpawnObject()
    {
        transform.DOScaleX(15f, 1f).SetEase(Ease.InElastic);
        StartCoroutine(TimeAlive());
    }
}
