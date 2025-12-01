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
    private Tween t;

    
    private float hauteurBoss = 5;
    private float timeToGoUp = 1;
    private Ease ease = Ease.InOutQuint;

    protected override Status OnStart()
    {
        t = Self.Value.transform.DOMoveY(hauteurBoss, timeToGoUp).SetEase(ease);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (t.IsComplete())
            return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

