using UnityEngine;

public class Bounce : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall") && this.enabled == true)
        {
            rb.linearVelocity = -rb.linearVelocity;
        }
    }
}
