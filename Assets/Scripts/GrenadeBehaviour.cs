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
        transform.localScale = Vector3.zero;
        StartCoroutine(KillGrenade());
    }
    private IEnumerator KillGrenade()
    {
        float _offset = Offset();
        yield return new WaitForSeconds(_offset);
        scaleTween = transform.DOScale(new Vector3(size, 1, size), timeAlive- _offset).SetEase(Ease.OutElastic);
        yield return scaleTween.WaitForCompletion();
        Destroy(gameObject);
    }

    private float Offset()
    {
        return Random.Range(0, offsetSpawn);
    }
}
