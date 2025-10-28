using DG.Tweening;
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DigletAttack", story: "[Self] goes in Ground", category: "Action", id: "cbcc1481329a4d352451e3e3302cb352")]
public partial class DigletAttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    private Tween tw;

    private float speed = 5f;
    protected override Status OnStart()
    {
        tw = Self.Value.transform.DOMoveY(1f, 1f/ speed)
            .SetEase(Ease.InOutQuint)
            .OnComplete(() =>
            {
                Self.Value.GetComponent<Boss_Variables>().SetDestroying();
                tw = Self.Value.transform.DOMoveY(-10f, 1f/speed).SetEase(Ease.InOutQuint);
            });
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (!tw.IsPlaying())
            return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

