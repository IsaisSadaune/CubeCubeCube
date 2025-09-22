using UnityEngine;
using DG.Tweening;
using System.Collections;
public class GrenadeBehaviour : MonoBehaviour
{
    private Tween scaleTween;
    [SerializeField] private float timeAlive;
    [SerializeField] private float size;
    [SerializeField] private float offsetSpawn;

    private void Start()
    {
        StartCoroutine(KillGrenade());
    }
    private IEnumerator KillGrenade()
    {
        yield return new WaitForSeconds(Offset());
        scaleTween = transform.DOScale(new Vector3(transform.localScale.x * size, transform.localScale.y, transform.localScale.z * size), timeAlive).SetEase(Ease.OutElastic);
        yield return scaleTween.WaitForCompletion();
        Destroy(gameObject);
    }

    private float Offset()
    {
        return Random.Range(0, offsetSpawn);
    }
}
