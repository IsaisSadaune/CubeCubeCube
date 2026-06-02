using System.Collections;
using UnityEngine;

public class GapClose : MonoBehaviour
{
    private Player player;
    public int mp_Cost;
    public int damage;
    public bool isUlting;
    public GameObject hitPrevi;
    public GameObject posPrevi;
    public LayerMask wallLayer;
    public BoxCollider hitCollider { get; set; }

    void Start()
    {
        player = GetComponent<Player>();
        hitCollider = hitPrevi.GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (isUlting && player.actualSuper == Super.GapClose)
        {
            if (!hitPrevi.activeSelf || !posPrevi.activeSelf)
            {
                hitPrevi.SetActive(true);
                posPrevi.SetActive(true);
            }
        }
        else
        {
            hitPrevi.SetActive(false);
            posPrevi.SetActive(false);
        }
    }
    public void GapClosing()
    {
        if (!isUlting)
        {
            hitPrevi.SetActive(false);
            posPrevi.SetActive(false);

            float distance = Vector3.Distance(transform.position + Vector3.up, posPrevi.transform.position);
            Vector3 dir = (posPrevi.transform.position - transform.position).normalized;
            RaycastHit hit;

            StartCoroutine(ColliderActivation());

            player.hps.current_mp = 0;
            player.hps.rageBar.DecreaseBarValue(mp_Cost);

            if (Physics.Raycast(transform.position, dir, out hit, distance, wallLayer))
            {
                player.rb.MovePosition(hit.point);
                player.stateMachine.ChangeState(player.idleState);
            }
            else
            {
                player.rb.MovePosition(posPrevi.transform.position);
                player.stateMachine.ChangeState(player.idleState);
            }

        }
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
