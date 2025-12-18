using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "JumpDice", story: "[Self] jump at [Position]", category: "Action", id: "6adc78af0c092e7b24d245a9633b4da6")]
public partial class JumpDiceAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Transform> Position;
    private Tween t;

    protected override Status OnStart()
    {
        t = Self.Value.transform.DOJump(Position.Value.position, 15f, 1, 1.5f).SetEase(Ease.OutQuint);
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

