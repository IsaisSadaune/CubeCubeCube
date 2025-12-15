using UnityEngine;

public class PlayerDoingDamage : MonoBehaviour
{
    public Player player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IDamageable>(out IDamageable cible) && !other.CompareTag("Player"))
        {
            player.bossHit = true;
            cible.TakeDamage(player.combo[player.comboCount].damage);   
        }
    }
}
