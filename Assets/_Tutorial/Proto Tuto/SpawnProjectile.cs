using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform endPosition;

    private Sequence s;

    private void Start()
    {
        StartCoroutine(CooldownSpawnProjectile());
    }

    private IEnumerator CooldownSpawnProjectile()
    {
        yield return new WaitForSeconds(cooldown);
        GameObject p = Instantiate(projectile, transform.position, projectile.transform.rotation, transform);
        
        s = DOTween.Sequence();
        s.Append(p.transform.DOMove(endPosition.position, 3f));
        s.Append(p.transform.DOScale(0, 1f));
        s.OnComplete(() => Destroy(p));
        StartCoroutine(CooldownSpawnProjectile());
    }
}
