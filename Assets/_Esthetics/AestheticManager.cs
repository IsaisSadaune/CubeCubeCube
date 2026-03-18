using DG.Tweening;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AestheticManager : MonoBehaviour
{
    [SerializeField] private List<OrderElements> elements;


    [ContextMenu("1")]
    public void Set1()
    {
        foreach (var element in elements)
        { 
            element.test1();
        }
    }


    [ContextMenu("2")]
    public void Set2()
    {
        foreach (var element in elements)
        { 
            element.test2();
        }
    }

    [ContextMenu("3")]
    public void Set3()
    {
        foreach (var element in elements)
        { 
            element.test3();
        }
    }

    [ContextMenu("4")]
    public void Set4()
    {
        foreach (var element in elements)
        { 
            element.test4();
        }
    }

    [ContextMenu("5")]
    public void Set5()
    {
        foreach (var element in elements)
        { 
            element.test5();
        }
    }

    [ContextMenu("6")]
    public void Set6()
    {
        foreach (var element in elements)
        { 
            element.test6();
        }
    }

    [ContextMenu("Comeback")]
    public void ComeBack()
    {
        foreach (var element in elements)
        {
            Sequence s = DOTween.Sequence();
            s.Append(element.Center());
            s.Append(element.ComeBack());
        }
    }

}
