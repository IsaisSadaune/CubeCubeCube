using UnityEngine;

public class GroundCucubeDetector : MonoBehaviour
{
    [SerializeField] private Cucube_Deplacement ce;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            StartCoroutine(ce.StartMovement());
        }
    }

}
