using System.Collections;
using UnityEngine;
using DG.Tweening;
public class Cube_Explosif : MonoBehaviour
{
    //Previ explosion prefab
    [SerializeField] private GameObject boum;
    private Rigidbody rb => GetComponent<Rigidbody>();

    public IEnumerator StartExplosion()
    {
        //SetupPreviPrefab
        Debug.Log("ping");
        rb.isKinematic = true;
        yield return new WaitForSeconds(0.75f);
        boum.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        boum.SetActive(false);
        transform.DOScale(Vector3.zero, 1f).OnComplete( () => Destroy(gameObject) );
        //Explosion

        //Destroy
    }
}
