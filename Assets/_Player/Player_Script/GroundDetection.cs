using Unity.VisualScripting;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    private Player player;
    public LayerMask groundLayer;

    void Start()
    {
        player = GetComponentInParent<Player>();
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Ground" || Physics.Raycast(transform.position, Vector3.down, 1f, groundLayer))
        {
            player.isGrounded = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Ground")
        {
            player.isGrounded = false;
        }
    }

}
