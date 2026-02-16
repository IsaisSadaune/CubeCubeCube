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
        if(other.TryGetComponent(out IDamageable cible) && !other.CompareTag("Player"))
        {
            Debug.Log("dgt");
            player.bossHit = true;
            cible.TakeDamage(player.combo[player.comboCount].damage);   
        }
        else if(other.transform.parent != null && other.transform.parent.TryGetComponent(out IDamageable cible2) && !other.CompareTag("Player"))
        {
            Debug.Log("dgt");
            player.bossHit = true;
            cible2.TakeDamage(player.combo[player.comboCount].damage);
        }
    }
}
