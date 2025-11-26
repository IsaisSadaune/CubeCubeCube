using UnityEngine;
using System.Collections.Generic;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private List<SlabController> slabs;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PING");
        if(other.CompareTag("PlayerHitbox"))
        {
            if(!other.transform.parent.GetComponent<Player>().iFraming)
                other.transform.parent.GetComponent<HP_Test>().LoseHP(1);
            HardRespawn();
            other.transform.parent.position = respawnPoint.transform.position;
        }
    }


    private void HardRespawn()
    {
        foreach (var slab in slabs)
        {
            slab.Apparition();
        }
    }
}
