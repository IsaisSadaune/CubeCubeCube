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
        if (!other.CompareTag("Player"))
        {
            IDamageable cible  = null;
            if (other.GetComponent<IDamageable>() != null)
                cible = GetComponent<IDamageable>();
            else if (other.transform.parent.GetComponent<IDamageable>() != null)
                cible = other.transform.parent.GetComponent<IDamageable>();

            if (cible != null)
            {
                player.hps.GainMP(3);
                player.bossHit = true;
                if (gameObject.tag == "Attack")
                    cible.TakeDamage(player.combo[player.comboCount].damage);
                else
                    cible.TakeDamage(player.gapClose.damage);
            }
        }
    }
}
