using UnityEngine;

public class PlayerTakesDamage : MonoBehaviour
{
    [SerializeField] private HP_Test hps;
    [SerializeField] private Player p;

    private void OnTriggerEnter(Collider other)
    {
        //ISAIS : ajout du trigger Boss 
        //C'EST DEGUEULASSE !!!!!!!!!!!!
        if (other.CompareTag("Boss") && !p.iFraming)
        {
            p.iFraming = true;
            p.Knockback(other.transform);
            p.TakeDamage(2);
        }
    }

}
