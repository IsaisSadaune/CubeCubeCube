using System.Collections;
using UnityEngine;

public class TMP_playerDMG : MonoBehaviour
{
    [SerializeField] private Material m_damaged;
    private Material m_idle;

    private bool canBeDamaged = true;

    private void Start()
    {
        m_idle = transform.GetComponent<Renderer>().material;
    }

    public void Damage()
    {
        if (canBeDamaged)
        {
            //transform.GetComponent<Rigidbody>().isKinematic = true;
            transform.GetComponent<Renderer>().material = m_damaged;
            canBeDamaged = false;
            StartCoroutine(CooldownDamaged());
        }
    }

    private IEnumerator CooldownDamaged()
    {
        yield return new WaitForSeconds(0.75f);
        canBeDamaged = true;
        transform.GetComponent<Renderer>().material = m_idle;
        transform.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out TMP_BossControler c))
        {
            Damage();
        }
    }
}
