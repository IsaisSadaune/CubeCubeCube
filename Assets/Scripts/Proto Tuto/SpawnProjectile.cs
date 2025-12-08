using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    [SerializeField] private float f;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform endPosition;



    private void Start()
    {
        StartCoroutine(CooldownSpawnProjectile());
    }

    private IEnumerator CooldownSpawnProjectile()
    {
        yield return new WaitForSeconds(f);
        GameObject p = Instantiate(projectile, transform.position, projectile.transform.rotation, transform);
        p.transform.DOMove(endPosition.position, 3f).OnComplete(() => Destroy(p.gameObject));
        StartCoroutine(CooldownSpawnProjectile());
    }
}
