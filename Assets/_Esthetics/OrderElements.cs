using UnityEngine;
using DG.Tweening;
using NUnit.Framework;
using System.Collections.Generic;

public class OrderElements : MonoBehaviour
{
    
    [SerializeField] private Transform parent;

    private Vector3 pos1 => parent.GetChild(0).position;

    private Vector3 pos2 => parent.GetChild(1).position;

    private Vector3 pos3 => parent.GetChild(2).position;

    private Vector3 pos4 => parent.GetChild(3).position;

    private Vector3 pos5 => parent.GetChild(4).position;

    private Vector3 pos6 => parent.GetChild(5).position;

    private Vector3 pos0 => parent.GetChild(6).position;


    private List<Vector3> position = new();

    private Sequence seq;


    [ContextMenu("test1")]
    public void test1()
    {
        seq = DOTween.Sequence();
        seq.Append(Center(1));
        seq.Append(SetTo1());
    }
    [ContextMenu("test2")]
    public void test2()
    {
        seq = DOTween.Sequence();
        seq.Append(Center(2));
        seq.Append(SetTo2());
    }
    [ContextMenu("test3")]
    public void test3()
    {
        seq = DOTween.Sequence();
        seq.Append(Center(3));
        seq.Append(SetTo3());
    }
    [ContextMenu("test4")]
    public void test4()
    {
        seq = DOTween.Sequence();
        seq.Append(Center(4));
        seq.Append(SetTo4());
    }
    [ContextMenu("test5")]
    public void test5()
    {
        seq = DOTween.Sequence();
        seq.Append(Center(5));
        seq.Append(SetTo5());
    }
    [ContextMenu("test6")]
    public void test6()
    {
        seq = DOTween.Sequence();
        seq.Append(Center(6));
        seq.Append(SetTo6());
    }




    private Sequence SetTo1()
    {
        Sequence s = DOTween.Sequence();
        s.Join(transform.GetChild(0).DOMove(pos0, 0.5f));
        return s;
    }
    private Sequence SetTo2()
    {
        Sequence s = DOTween.Sequence();
        s.Join(transform.GetChild(0).DOMove(pos1, 0.5f));
        s.Join(transform.GetChild(1).DOMove(pos6, 0.5f));
        return s;
    }
    private Sequence SetTo3()
    {
        Sequence s = DOTween.Sequence();
        s.Join(transform.GetChild(0).DOMove(pos1, 0.5f));
        s.Join(transform.GetChild(1).DOMove(pos0, 0.5f));
        s.Join(transform.GetChild(2).DOMove(pos6, 0.5f));
        return s;
    }
    private Sequence SetTo4()
    {
        Sequence s = DOTween.Sequence();
        s.Join(transform.GetChild(0).DOMove(pos1, 0.5f));
        s.Join(transform.GetChild(1).DOMove(pos3, 0.5f));
        s.Join(transform.GetChild(2).DOMove(pos4, 0.5f));
        s.Join(transform.GetChild(3).DOMove(pos6, 0.5f));
        return s;
    }
    private Sequence SetTo5()
    {
        Sequence s = DOTween.Sequence();
        s.Join(transform.GetChild(0).DOMove(pos1, 0.5f));
        s.Join(transform.GetChild(1).DOMove(pos3, 0.5f));
        s.Join(transform.GetChild(3).DOMove(pos4, 0.5f));
        s.Join(transform.GetChild(4).DOMove(pos6, 0.5f));
        s.Join(transform.GetChild(5).DOMove(pos0, 0.5f));
        return s;
    }

    private Sequence SetTo6()
    {
        Sequence s = DOTween.Sequence();
        s.Join(transform.GetChild(0).DOMove(pos1, 0.5f));
        s.Join(transform.GetChild(1).DOMove(pos2, 0.5f));
        s.Join(transform.GetChild(2).DOMove(pos3, 0.5f));
        s.Join(transform.GetChild(3).DOMove(pos4, 0.5f));
        s.Join(transform.GetChild(4).DOMove(pos5, 0.5f));
        s.Join(transform.GetChild(5).DOMove(pos6, 0.5f));
        return s;
    }




    [ContextMenu("reset")]
    public Sequence ComeBack()
    {
        Sequence s = DOTween.Sequence();
        for (int i = 0; i < 6; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            s.Join(transform.GetChild(i).DOMove(position[i], 0.5f));
        }
        position.Clear();
        return s;
    }

    public Sequence Center(int number=6)
    {
        Sequence s = DOTween.Sequence();
        for (int i = 0; i < 6; i++)
        {
            int index = i;
            Tween t = transform.GetChild(index).DOMove(parent.GetChild(transform.childCount).position, 0.5f);
            position.Add(transform.GetChild(index).position);
            if (index >= number)
                t.OnComplete(() => transform.GetChild(index).gameObject.SetActive(false));

            s.Join(t);
        }
        return s;
    }
}