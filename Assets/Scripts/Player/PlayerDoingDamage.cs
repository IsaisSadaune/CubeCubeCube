using UnityEngine;

public class PlayerDoingDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IDamageable>(out IDamageable cible) && !other.CompareTag("Player"))
        {
            cible.TakeDamage(10);
        }
    }
}
