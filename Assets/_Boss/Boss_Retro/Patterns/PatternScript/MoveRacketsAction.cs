using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveRackets", story: "Move [RacketLeft] and [RacketRight] To Arena and set [RacketsUp]", category: "Action", id: "dcd130a72d41718ff44732a11a2ff414")]
public partial class MoveRacketsAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> RacketLeft;
    [SerializeReference] public BlackboardVariable<GameObject> RacketRight;
    [SerializeReference] public BlackboardVariable<bool> RacketsUp;
    protected override Status OnStart()
    {
        RacketLeft.Value.transform.DOMoveY(1, 1f).SetEase(Ease.Linear);
        RacketRight.Value.transform.DOMoveY(1, 1f).SetEase(Ease.Linear).OnComplete(() 
        =>{RacketsUp.Value = true;});
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

