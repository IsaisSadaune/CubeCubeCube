using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TetrisPiece : MonoBehaviour
{
    SlabController tile;
    private void Awake()
    {
        StartCoroutine(DestroyingGround());
    }

    IEnumerator DestroyingGround()
    {
        yield return new WaitForSeconds(0.3f);
        transform.DOMoveY(0.5f, 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.75f);
        // Idée à équilibrer mais c'est golri

        // if(gameObject.name == "SquarePiece(Clone)")
        // {
        //    Vector3 dir = GetClosestOrthogonalDirection(transform, Player.Instance.transform.position);
        //     gameObject.transform.DOMove(dir * 50, 2f).OnComplete(()=>Destroy(gameObject)); 
        // }
        // else

        Destroy(gameObject);
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            Debug.Log("Collision with ground");

        }
    }

    public Vector3 GetClosestOrthogonalDirection(Transform from, Vector3 targetPosition)
    {
        Vector3 directionToTarget = targetPosition - from.position;
        directionToTarget.y = 0;
        directionToTarget.Normalize();

        float absX = Mathf.Abs(directionToTarget.x);
        float absZ = Mathf.Abs(directionToTarget.z);

        if (absX > absZ)
        {
            return directionToTarget.x > 0 ? Vector3.right : Vector3.left;
        }
        else
        {
            return directionToTarget.z > 0 ? Vector3.forward : Vector3.back;
        }
    }
}
