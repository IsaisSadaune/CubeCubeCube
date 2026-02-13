using Unity.VisualScripting;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GetComponentInParent<Player>();
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Ground")
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
