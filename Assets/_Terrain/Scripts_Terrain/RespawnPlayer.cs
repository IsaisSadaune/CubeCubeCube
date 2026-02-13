using UnityEngine;
using System.Collections.Generic;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private List<SlabController> slabs;
    [SerializeField] private Player p;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("PING");
        if(other.CompareTag("Player"))
        {
            if(!other.transform.GetComponent<Player>().iFraming)
                other.transform.GetComponent<HP_Test>().LoseHP(1);
            HardRespawn();
            p.hasFalledRecently = true;
            other.transform.position = respawnPoint.position;
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
