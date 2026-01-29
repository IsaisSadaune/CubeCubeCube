using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SlabController : MonoBehaviour
{
    private Vector3 scale;
    private float timeDestroyed = 1f;
    private Color startColor;

    [SerializeField] private GameObject model;
    private void Start()
    {
        startColor = model.GetComponent<MeshRenderer>().material.color;
        scale = transform.localScale;
    }

    public void Disparition()
    {
        transform.DOScale(Vector3.zero, 0.5f);
        StartCoroutine(ReconstructionCoroutine(timeDestroyed));
    }

    public Tween Apparition()
    {
        return transform.DOScale(scale, 0.5f);
    }
    public void Destroyed()
    {
        //Debug.Log("destroyed function");
        Disparition();
    }

    private IEnumerator ReconstructionCoroutine(float timebeforeRepop)
    {
        //Debug.Log("ReconstructionCoroutine");
        yield return new WaitForSeconds(timebeforeRepop);
        Apparition();
    }
}
