using UnityEngine;
using System.Collections;
using DG.Tweening;
public class DamageZoneBehaviour : MonoBehaviour
{
    public float TimeActive;

    private void Start()
    {
        if(TimeActive <= 0) TimeActive = 1f;
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
        transform.DOPunchScale(Vector3.one * 1.1f, 1f, 2, 0.25f);
        StartCoroutine(TimeAlive());
    }

}
