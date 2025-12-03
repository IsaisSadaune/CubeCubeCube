using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Thwomp", story: "[Self] stop then stomp", category: "Action", id: "fff7aa48212834ddcc3440543f896723")]
public partial class ThwompAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    private bool finished = false;

    private float timeToStomp = 1f;
    private Ease ease = Ease.InQuint;

    protected override Status OnStart()
    {
        finished = false;
        Self.Value.transform.DOMoveY(0, timeToStomp)
            .SetEase(ease)
            .OnComplete(() => finished = true);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(finished)
            return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

