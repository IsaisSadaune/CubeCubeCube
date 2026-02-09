using System.Collections;
using UnityEngine;

public class Cube_Explosif : MonoBehaviour
{
    //Previ explosion prefab

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            StartCoroutine(StartExplosion());
        }
    }

    private IEnumerator StartExplosion()
    {
        //SetupPreviPrefab
        
        yield return new WaitForSeconds(1f);
        
        //Explosion

        //Destroy
    }
}
