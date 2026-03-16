using UnityEngine;


/// <summary>
/// Proc quand le joueur subit un d�gat.
/// Se place sur la hitbox du joueur.
/// </summary>
public class PlayerTakesDamage : MonoBehaviour
{
    [SerializeField] private Player p;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss") && !p.iFraming)
        {
            p.iFraming = true;
            p.Knockback(other.transform);
            p.TakeDamage(1);
        }
        else if (other.CompareTag("FakeDamage") && !p.iFraming)
        {
            p.iFraming = true;
            p.Knockback(other.transform);
            p.TakeDamage(0);
        }
        if(other.CompareTag("Projectile") && !p.iFraming)
        {
            p.iFraming = true;
            p.TakeDamage(1);
        }
    }

}
