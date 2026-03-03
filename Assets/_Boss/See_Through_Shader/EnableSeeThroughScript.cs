using UnityEngine;

public class EnableSeeThroughScript : MonoBehaviour
{
    public bool playerBehindBoss;
    public Transform playerPosition, cameraPosition;
    public Shader seeThroughMaterial;
    private RaycastHit hitInfo;

    private void Update()
    {
        if (Physics.Linecast(cameraPosition.position, playerPosition.position, out hitInfo))
        {
            if (hitInfo.collider.CompareTag("Boss"))
                playerBehindBoss = true;
            else 
                playerBehindBoss = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(cameraPosition.position, (playerPosition.position - cameraPosition.position));
    }
}
