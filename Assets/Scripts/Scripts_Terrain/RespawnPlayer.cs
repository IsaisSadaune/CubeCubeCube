using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PING");
        if(other.CompareTag("Player"))
        {
            other.transform.position = respawnPoint.transform.position;
        }
    }
}
