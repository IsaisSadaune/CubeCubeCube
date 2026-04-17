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
        transform.DOMoveY(1f, 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.7f);
        transform.DOMoveY(-10f, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            Debug.Log("Collision with ground");
            tile = other.transform.parent.GetComponent<SlabController>();
            tile.Destroyed();
        }
    }
}
