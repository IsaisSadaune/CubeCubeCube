using UnityEngine;

public class ExploDetector : MonoBehaviour
{
    [SerializeField] private Cube_Explosif ce;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            StartCoroutine(ce.StartExplosion());
        }
    }
}
