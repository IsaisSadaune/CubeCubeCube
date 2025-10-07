using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DigletAttack", story: "[Self] goes in Ground", category: "Action", id: "cbcc1481329a4d352451e3e3302cb352")]
public partial class DigletAttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    private Sequence sequence;
    protected override Status OnStart()
    {
        Self.Value.GetComponent<Boss_Variables>().SetDestroying();
        sequence = DOTween.Sequence();
        sequence
            .Append(Self.Value.transform.DOMoveY(1f, 1f)).SetEase(Ease.InOutQuint)
            .Append(Self.Value.transform.DOMoveY(-10f, 1f).SetEase(Ease.InOutQuint));
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(!sequence.IsPlaying())
            return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

