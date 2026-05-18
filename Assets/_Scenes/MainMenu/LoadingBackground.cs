using System.Collections;
using DG.Tweening;
using UnityEngine;

public class LoadingBackground : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(MovingDown());
    }
    void OnDisable()
    {
        StopCoroutine(MovingDown());
    }

    IEnumerator MovingDown()
    {
        while (true)
        {
            transform.DOMoveY(transform.position.y - 1, 0.05f);
            yield return null;   
        }
        
    }
}
