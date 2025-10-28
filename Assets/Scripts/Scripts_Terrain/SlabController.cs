using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SlabController : MonoBehaviour
{
    private Vector3 scale;
    private float timeSlimed = 1f;
    private float timeDestroyed = 2f;

    [SerializeField] private GameObject model;
    private void Start()
    {
        scale = transform.localScale;
    }

    public void Disparition()
    {
        transform.DOScale(Vector3.zero, 0.5f);
        StartCoroutine(ReconstructionCoroutine(timeDestroyed));
    }

    public Tween Apparition() => transform.DOScale(scale, 0.5f);

    public void Destroyed()
    {
        Debug.Log("destroyed function");
        Disparition();
    }


    private Coroutine isSlimed;
    public void Slimed()
    {
        Debug.Log("slimed function");
        if (isSlimed != null) StopCoroutine(isSlimed);
        isSlimed = StartCoroutine(SlimeCoroutine());
    }

    private IEnumerator SlimeCoroutine()
    {
        Debug.Log("StartSlimeCoroutine");
        model.GetComponent<MeshRenderer>().material.color = Color.green;
        yield return new WaitForSeconds(timeSlimed);
        model.GetComponent<MeshRenderer>().material.color = Color.white;
    }

    private IEnumerator ReconstructionCoroutine(float timebeforeRepop)
    {
        Debug.Log("ReconstructionCoroutine");
        yield return new WaitForSeconds(timebeforeRepop);
        Apparition();
    }
}
