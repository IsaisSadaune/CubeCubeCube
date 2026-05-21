using UnityEngine;
using System.Collections;

public class SpawnProjectilesCubes : MonoBehaviour
{
    [SerializeField] private GameObject Cucubes;

    private void Start()
    {
        StartCoroutine(SpawnProjectile());
    }
    
    private IEnumerator SpawnProjectile()
    {
        float xPos = transform.position.x + Random.Range(-14f, 14f);

        Instantiate(Cucubes, transform.position + Vector3.right*xPos, Quaternion.identity);
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(SpawnProjectile());
    }
}
