using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class Recreator : MonoBehaviour
{
    [SerializeField] private List<Transform> childCubes;
    private List<Vector3> childCubesOGpos;

    private void Awake()
    {
        childCubesOGpos = new();
        foreach (var child in childCubes)
            childCubesOGpos.Add(child.transform.position);
    }


    [ContextMenu("test")]
    public Sequence Top10CubeComebacks()
    {
        Sequence s = DOTween.Sequence();
        for(int i = 0; i < childCubes.Count; i++)
        {
            childCubes[i].GetComponent<Rigidbody>().isKinematic = true;
            s.Join(childCubes[i].DOMove(childCubesOGpos[i],1.25f).OnComplete( () => childCubes[i].position = childCubesOGpos[i]).SetEase(Ease.OutQuad));
            s.Join(childCubes[i].DORotate(Vector3.zero,1.25f).OnComplete( () => childCubes[i].rotation = Quaternion.identity).SetEase(Ease.OutQuad));
        }
        return s;
    }

    public void ResetCubes()
    {
        foreach (var child in childCubes)
            child.GetComponent<Rigidbody>().isKinematic = false;
    }
}
