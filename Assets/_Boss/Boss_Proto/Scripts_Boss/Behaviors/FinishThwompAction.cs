using DG.Tweening;
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Finish Thwomp", story: "[Self] fall", category: "Action", id: "85c4d16275fa241848b690c01baba5ec")]
public partial class FinishThwompAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    private float timeToStomp = 1f;
    private Ease ease = Ease.InOutQuint; //Changer easing
    private Tween finished;

    protected override Status OnStart()
    {
        finished = 
        Self.Value.transform.DOMoveY(-0.21f, timeToStomp)
            .SetEase(ease);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (!finished.IsPlaying())
            return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {

    }


}

