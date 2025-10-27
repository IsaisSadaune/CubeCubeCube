using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SlabController : MonoBehaviour
{
    private Vector3 scale;
    private float timebeforeRepop = 1f;
    private Coroutine isSlimed;
    [SerializeField] private GameObject model;
    private void Start()
    {
        scale = transform.localScale;
    }

    public void Disparition()
    {
        Sequence s = DOTween.Sequence();
        s.Append(transform.DOScale(Vector3.zero, 0.5f))
            .AppendInterval(1f)
            .Append(Apparition());
    }

    public Tween Apparition()
    {
        return transform.DOScale(scale, 0.5f);
    }

    public void Destroyed()
    {
        Debug.Log("destroyed function");
        Disparition();
    }

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
        yield return new WaitForSeconds(timebeforeRepop);
        model.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
