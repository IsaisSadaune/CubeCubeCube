using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dice1_Thwomp", story: "[Self] goes Up", category: "Action", id: "8a29414cc295e410bf511dad269c9b74")]
public partial class Dice1ThwompAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    private Sequence t;



    private float timeToGoUp = 1;
    private Ease ease = Ease.InOutQuint;

    protected override Status OnStart()
    {
        Vector3 scale = Self.Value.transform.localScale;
        t = DOTween.Sequence();
        t.Append(Self.Value.transform.DOMoveY(20, timeToGoUp).SetEase(ease));
        t.Append(Self.Value.transform.DOScale(Vector3.zero, 0.25f));
        //Attention c'est pas dans la sequence c'est normal
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (!t.IsPlaying())
            return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

