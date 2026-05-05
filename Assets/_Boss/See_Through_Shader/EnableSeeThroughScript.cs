using UnityEngine;
using DG.Tweening;

public class EnableSeeThroughScript : MonoBehaviour
{
    [SerializeField] private bool playerBehindBoss;
    [SerializeField] private Transform playerPosition, raycastDirection;
    [SerializeField] private LayerMask layerMask;
    private Material _materialInstance; 
    private RaycastHit hitInfo;
    float opacityValue = 1f; 

    private void Start()
    {
        _materialInstance = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        raycastDirection.position = new Vector3(playerPosition.position.x - 20, 5, playerPosition.position.z - 20);

        if (Physics.Linecast(raycastDirection.position, playerPosition.position, out hitInfo, layerMask))
        {
            if (hitInfo.collider.CompareTag("BossModel"))
                playerBehindBoss = true;
            else
                playerBehindBoss = false;
        }
        else
            playerBehindBoss = false;
        

        if (playerBehindBoss)
        {
            DOTween.To(() => opacityValue, x => opacityValue = x, 0.8f, 0.2f);
            _materialInstance.SetFloat("_BossOpacity", opacityValue); 
        }
        else
        {
            DOTween.To(() => opacityValue, x => opacityValue = x, 1, 0.2f);
            _materialInstance.SetFloat("_BossOpacity", opacityValue);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(raycastDirection.position, playerPosition.position);
    }
}
