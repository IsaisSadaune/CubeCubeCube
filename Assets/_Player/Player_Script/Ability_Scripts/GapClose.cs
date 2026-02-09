using System.Collections;
using UnityEditor.Callbacks;
using UnityEngine;

public class GapClose : MonoBehaviour
{
    private Player player;
    public int damage;
    [SerializeField] private GameObject boss;
    public GameObject hitPrevi; 
    public GameObject posPrevi; 
    public LayerMask wallLayer;
    public BoxCollider hitCollider {get; set;}

    void Start()
    {
        player = GetComponent<Player>();
        hitCollider = hitPrevi.GetComponent<BoxCollider>();
    }

    public void GapClosing()
    {
        float distance = Vector3.Distance(transform.position + Vector3.up, posPrevi.transform.position);
        Vector3 dir = (posPrevi.transform.position - transform.position).normalized;
        RaycastHit hit;
        StartCoroutine(ColliderActivation());
        if(Physics.Raycast(transform.position, dir, out hit, distance, wallLayer))
        {
            Debug.Log("A");
            player.rb.MovePosition(hit.point);
            player.stateMachine.ChangeState(player.idleState);
        }
        else
        {
            Debug.Log("B");
            player.rb.MovePosition(posPrevi.transform.position);
            player.stateMachine.ChangeState(player.idleState);
        }
    }
    void OnDrawGizmos()
    {
        if (posPrevi == null) return;

        Gizmos.color = Color.red;

        Vector3 dir = (posPrevi.transform.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, posPrevi.transform.position);

        Gizmos.DrawRay(transform.position + Vector3.up, dir * distance);

        // Petit sphere au point cible
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(posPrevi.transform.position, 0.2f);
    }

    IEnumerator ColliderActivation()
    {
        GameObject attack = Instantiate(hitPrevi, hitPrevi.transform.position, hitPrevi.transform.rotation);
        attack.SetActive(true);
        attack.AddComponent<BoxCollider>().isTrigger = true;
        yield return new WaitForSeconds(1f);
        Destroy(attack);
    }
}
