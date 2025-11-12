using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PING");
        if(other.CompareTag("Player"))
        {
            other.GetComponent<HP_Test>().LoseHP(2);
            other.transform.position = respawnPoint.transform.position;
        }
    }
}
