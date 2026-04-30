using UnityEngine;

public class SeeThroughDetectorPositionScript : MonoBehaviour
{
    [SerializeField] private Transform raycastDirectionPosition;
    [SerializeField] private GameObject player;

    private void Update()
    { 
        raycastDirectionPosition.position = new Vector3(player.transform.position.x - 20, transform.position.y, player.transform.position.z - 20);
    }
}
