using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GoToDestinationX", story: "[Self] Goes to [positionX] x in [X] seconds", category: "Action", id: "d34a3bb266c346f0d4529db98e07967c")]
public partial class GoToDestinationXAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Transform> PositionX;
    [SerializeReference] public BlackboardVariable<float> X;
    Tween t;

    protected override Status OnStart()
    {
        t = Self.Value.transform.DOMoveX(PositionX.Value.transform.position.x, 1f / X).SetEase(Ease.InOutQuint);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(!t.IsPlaying())
            return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

