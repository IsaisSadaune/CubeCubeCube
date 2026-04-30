using UnityEngine;

public class RespawnBoxScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform teleportLocation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = teleportLocation.position;
            player.transform.rotation = teleportLocation.rotation;
        }
    }

    public void SetNewSpawnPoint(Transform newspawn)
    {
        teleportLocation = newspawn;
    }

}
