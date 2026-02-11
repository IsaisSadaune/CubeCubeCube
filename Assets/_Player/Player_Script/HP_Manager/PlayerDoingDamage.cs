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
            player.hps.GainMP(3);
            player.bossHit = true;
            if(gameObject.tag == "Attack")
                cible.TakeDamage(player.combo[player.comboCount].damage);
            else
                cible.TakeDamage(player.gapClose.damage);
        }
    }
}
