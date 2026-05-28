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
        if (player == null)
            player = GameManager_Offi.Instance.p;

        if (!other.CompareTag("Player") && !other.CompareTag("Projectile"))
        {
            IDamageable cible = null;
            if (other.GetComponent<IDamageable>() != null)
            {
                cible = other.GetComponent<IDamageable>();
            }
            else if (other.transform.parent != null && other.transform.parent.GetComponent<IDamageable>() != null)
                cible = other.transform.parent.GetComponent<IDamageable>();

            if (cible != null)
            {
                player.hps.GainMP(3);
                player.bossHit = true;
                Debug.Log(gameObject);
                if (gameObject.CompareTag("Attack"))
                {
                    Debug.Log("attaque boss");
                    cible.TakeDamage(player.combo[player.comboCount].damage);
                }
                else
                    cible.TakeDamage(player.gapClose.damage);
                    GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}