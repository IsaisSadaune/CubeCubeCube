using UnityEngine;

public class DestroyingItself : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
