using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class RubiksRotateTest : MonoBehaviour
{
    [SerializeField] private List<GameObject> RubiksCube;
    [SerializeField] private Transform i;
    [SerializeField] private Transform j;
    [SerializeField] private Transform k;
    [SerializeField] private Transform l;
    [SerializeField] private Transform m;
    [SerializeField] private Transform OGParent;

    [ContextMenu("Rotate I Alt")]
    public void RotateIAlt()
    {
        ResetPos();
        ResetParents();
        List<GameObject> o = GetObjectWithThisX(i.position.x);
        foreach (var v in o) v.transform.parent = i;
        i.transform.DORotate(new Vector3(90, 0, 0), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutQuint).OnComplete(() => ResetParents());
    }
    [ContextMenu("Rotate J Alt")]
    public void RotateJAlt()
    {
        ResetPos();
        ResetParents();
        List<GameObject> o = GetObjectWithThisZ(j.position.z);
        foreach (var v in o) v.transform.parent = j;
        j.transform.DORotate(new Vector3(0, 0, 90), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutQuint).OnComplete(() => ResetParents());
    }
    [ContextMenu("Rotate K1 Alt")]
    public void RotateK1Alt()
    {
        ResetPos();
        ResetParents();
        List<GameObject> o = GetObjectWithThisZ(k.position.z);
        foreach (var v in o) v.transform.parent = k;
        k.transform.DORotate(new Vector3(0, 0, 90), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutQuint).OnComplete(() => ResetParents());
    }
    [ContextMenu("Rotate K2 Alt")]
    public void RotateK2Alt()
    {
        ResetPos();
        ResetParents();
        List<GameObject> o = GetObjectWithThisX(k.position.x);
        foreach (var v in o) v.transform.parent = k;
        k.transform.DORotate(new Vector3(90, 0, 0), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutQuint).OnComplete(() => ResetParents());
    }
    [ContextMenu("Rotate L Alt")]
    public void RotateLAlt()
    {
        ResetPos();
        ResetParents();
        List<GameObject> o = GetObjectWithThisZ(l.position.z);
        foreach (var v in o) v.transform.parent = l;
        l.transform.DORotate(new Vector3(0, 0, 90), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutQuint).OnComplete(() => ResetParents());
    }
    [ContextMenu("Rotate M Alt")]
    public void RotateMAlt()
    {
        ResetPos();
        ResetParents();
        List<GameObject> o = GetObjectWithThisX(m.position.x);
        foreach (var v in o) v.transform.parent = m;
        m.transform.DORotate(new Vector3(90, 0, 0), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutQuint).OnComplete(() => ResetParents());
    }



    //Il est minuit ok laissez-moi test mes théories j'ai rallumé mon PC pour ça
    public List<GameObject> GetObjectWithThisX(float X)
    {
        List<GameObject> objects = new();
        foreach(var v in RubiksCube) if(Mathf.Approximately(v.transform.position.x, X)) objects.Add(v);
        return objects;
    }
    public List<GameObject> GetObjectWithThisZ(float Z)
    {
        List<GameObject> objects = new();
        foreach(var v in RubiksCube) if(Mathf.Approximately(v.transform.position.z, Z)) objects.Add(v);
        return objects;
    }


    private void ResetParents()
    {
        foreach(var v in RubiksCube) v.transform.parent = OGParent;
        i.rotation = Quaternion.identity;
        j.rotation = Quaternion.identity;
        k.rotation = Quaternion.identity;
        l.rotation = Quaternion.identity;
        m.rotation = Quaternion.identity;
    }
    private void ResetPos()
    {
        foreach(var v in RubiksCube)
        {
            float xValue = v.transform.position.x;
            float yValue = v.transform.position.y;
            float zValue = v.transform.position.z;
            if (xValue < 1 && xValue > -1) xValue = 0f;
            if (xValue < 6 && xValue > 4 ) xValue = 5f;
            if (xValue < -4 && xValue > -6) xValue = -5f;
            if (yValue < 1 && yValue > -1) yValue = 0f;
            if (yValue < 6 && yValue > 4 ) yValue = 5f;
            if (yValue < -4 && yValue > -6) yValue = -5f;
            if (zValue < 1 && zValue > -1) zValue = 0f;
            if (zValue < 6 && zValue > 4 ) zValue = 5f;
            if (zValue < -4 && zValue > -6) zValue = -5f;
            v.transform.position = new(xValue, yValue, zValue);

        }
    }

}
