using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System;
using System.Collections;

public class AxesPivot : MonoBehaviour
{
    [SerializeField]
    Axe axe;

    List<GameObject> childs = new List<GameObject>();

    [ContextMenu("Rotate")]
    public void Rotate(float duration = 2f)
    {
        Vector3 pivot = Vector3.zero;

        RegisterChilds();

        switch (axe)
        {
            case Axe.X:
                pivot = Vector3.right * 90;
                break;
            case Axe.Y:
                pivot = Vector3.up * 90;
                break;
            case Axe.Z:
                pivot = Vector3.forward * 90;
                break;
            default:
                break;
        }

        transform.DOBlendableRotateBy(pivot, duration).OnComplete(ResetChilds);
    }

    private void ResetChilds()
    {
        foreach (GameObject child in childs) 
        { 
            child.transform.SetParent(null);
        }

        childs.Clear();
    }

    void RegisterChilds()
    {
        Vector3 size = new Vector3();

        switch (axe)
        {
            case Axe.X:
                size = new Vector3(.1f, 1.5f, 1.5f);
                break;
            case Axe.Y:
                size = new Vector3(1.5f, .1f, 1.5f);
                break;
            case Axe.Z:
                size = new Vector3(1.5f, 1.5f, .1f);
                break;
            default:
                break;
        }

        Collider[] colliders = Physics.OverlapBox(transform.position, size, Quaternion.identity);

        foreach (Collider collider in colliders)
        {
            childs.Add(collider.gameObject);
            collider.transform.SetParent(transform);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 size = new Vector3();
        
        switch (axe)
        {
            case Axe.X:
                size = new Vector3(.1f, 1.5f, 1.5f);
                break;
            case Axe.Y:
                size = new Vector3(1.5f, .1f, 1.5f);
                break;
            case Axe.Z:
                size = new Vector3(1.5f, 1.5f, .1f);
                break;
            default:
                break;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, size * 2);
    }
}

public enum Axe
{
    X,
    Y,
    Z
}
