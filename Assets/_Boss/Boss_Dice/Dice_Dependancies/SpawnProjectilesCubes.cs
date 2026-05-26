using UnityEngine;
using System.Collections;

public class SpawnProjectilesCubes : MonoBehaviour
{
    [SerializeField] private GameObject Cucubes;


    
    public void SpawnCubes(float f)
    {
        Debug.Log("ping");
        StartCoroutine(Spawner(f));
    }

    private IEnumerator Spawner(float timeSpawn)
    {
        Debug.Log("pong");

        if (timeSpawn> 0f)
        { 
            SpawnProjectile();
            yield return new WaitForSeconds(0.25f);
            timeSpawn -= 0.25f;
            StartCoroutine(Spawner(timeSpawn));
        }
    }

    private void SpawnProjectile()
    {
        float xPos = transform.position.x + Random.Range(-14f, 14f);

        Instantiate(Cucubes, transform.position + Vector3.right*xPos, Quaternion.identity);

    }
}
