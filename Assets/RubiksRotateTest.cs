using UnityEngine;
using DG.Tweening;
public class RubiksRotateTest : MonoBehaviour
{
    [SerializeField] private GameObject A1;
    [SerializeField] private GameObject A2;
    [SerializeField] private GameObject A3;
    [SerializeField] private GameObject B1;
    [SerializeField] private GameObject B2;
    [SerializeField] private GameObject B3;
    [SerializeField] private GameObject C1;
    [SerializeField] private GameObject C2;
    [SerializeField] private GameObject C3;
    [SerializeField] private Transform i;
    [SerializeField] private Transform j;
    [SerializeField] private Transform k;
    [SerializeField] private Transform l;
    [SerializeField] private Transform m;
    [SerializeField] private Transform OGParent;

    [ContextMenu("Rotate I")]
    public void RotateI()
    {
        A1.transform.parent= i;
        B1.transform.parent= i;
        C1.transform.parent= i;
        i.transform.DORotate(new Vector3(360, 0, 0), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutQuint).OnComplete(() => ResetParents());
    }
    [ContextMenu("Rotate J")]
    public void RotateJ()
    {
        A1.transform.parent= j;
        A2.transform.parent= j;
        A3.transform.parent= j;
        j.transform.DORotate(new Vector3(0, 0, 360), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutQuint).OnComplete(() => ResetParents());
    }
    [ContextMenu("Rotate K1")]
    public void RotateK1()
    {
        A2.transform.parent= k;
        B2.transform.parent= k;
        C2.transform.parent= k;
        k.transform.DORotate(new Vector3(360, 0, 0), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutQuint).OnComplete(() => ResetParents());
    }
    [ContextMenu("Rotate K2")]
    public void RotateK2()
    {
        B1.transform.parent= k;
        B2.transform.parent= k;
        B3.transform.parent= k;
        k.transform.DORotate(new Vector3(0, 0, 360), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutQuint).OnComplete(() => ResetParents());
    }
    [ContextMenu("Rotate L")]
    public void RotateL()
    {
        C1.transform.parent= l;
        C2.transform.parent= l;
        C3.transform.parent= l;
        l.transform.DORotate(new Vector3(0, 0, 360), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutQuint).OnComplete(() => ResetParents());
    }
    [ContextMenu("Rotate M")]
    public void RotateM()
    {
        A3.transform.parent= m;
        B3.transform.parent= m;
        C3.transform.parent= m;
        m.transform.DORotate(new Vector3(360, 0, 0), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutQuint).OnComplete(() => ResetParents());
    }
    private void ResetParents()
    {
        A1.transform.parent = OGParent;
        A2.transform.parent = OGParent;
        A3.transform.parent = OGParent;
        B1.transform.parent = OGParent;
        B2.transform.parent = OGParent;
        B3.transform.parent = OGParent;
        C1.transform.parent = OGParent;
        C2.transform.parent = OGParent;
        C3.transform.parent = OGParent;
    }

}
