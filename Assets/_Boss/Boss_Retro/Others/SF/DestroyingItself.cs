using System.Collections;
using UnityEngine;

public class DestroyingItself : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyIfMissing());
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyIfMissing()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
