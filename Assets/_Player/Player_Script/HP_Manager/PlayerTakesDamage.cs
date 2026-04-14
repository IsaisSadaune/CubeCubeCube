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
        Debug.Log($"Trigger touché par : {other.gameObject.name} | Tag : {other.tag} | iFraming : {p.iFraming}");

        if (other.CompareTag("Boss") && !p.iFraming)
        {
            Debug.Log("degat du boss sur joueur");
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Boss") && !p.iFraming)
        {
            Debug.Log("degat du boss sur joueur");
            p.iFraming = true;
            p.Knockback(collision.transform);
            p.TakeDamage(1);
        }
    }
}
