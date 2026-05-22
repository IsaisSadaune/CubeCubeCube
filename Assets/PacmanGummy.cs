using UnityEngine;

public class PacmanGummy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boss"))
        {
            Destroy(this.gameObject);
        }
    }
}
