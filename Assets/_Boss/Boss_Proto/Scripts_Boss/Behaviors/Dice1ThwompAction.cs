using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dice1_Thwomp", story: "[Self] goes Up in [timeToGoUp] and disapear in [TimeToDisappear]", category: "Action", id: "8a29414cc295e410bf511dad269c9b74")]
public partial class Dice1ThwompAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<float> TimeToGoUp;
    [SerializeReference] public BlackboardVariable<float> TimeToDisappear;
    private Sequence t;


    private Ease ease = Ease.InOutQuint;

    protected override Status OnStart()
    {
        Vector3 scale = Self.Value.transform.localScale;
        t = DOTween.Sequence();
        t.Append(Self.Value.transform.DOMoveY(20, TimeToGoUp.Value).SetEase(ease));
        t.Append(Self.Value.transform.DOScale(Vector3.zero, TimeToDisappear.Value));
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

