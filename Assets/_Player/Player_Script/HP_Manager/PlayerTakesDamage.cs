using UnityEngine;


/// <summary>
/// Proc quand le joueur subit un dégat.
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
            p.TakeDamage(2);
        }
        else if (other.CompareTag("FakeDamage") && !p.iFraming)
        {
            p.iFraming = true;
            p.Knockback(other.transform);
            p.TakeDamage(0);
        }
    }

}
