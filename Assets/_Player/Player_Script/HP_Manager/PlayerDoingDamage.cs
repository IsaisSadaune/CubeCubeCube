using UnityEngine;

/// <summary>
/// Proc quand le joueur inflige des dommages.
/// Se place sur les hitbox d'attaque du joueur
/// </summary>
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
