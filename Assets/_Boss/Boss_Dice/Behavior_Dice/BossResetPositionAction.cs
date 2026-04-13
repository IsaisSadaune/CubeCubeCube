using System;
using Unity.Behavior;
using UnityEngine;
using DG.Tweening;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "BossResetPosition", story: "[Self] goes to center of the arena", category: "Action", id: "64f9df26f3cf98ceb32b2948e49b9101")]
public partial class BossResetPositionAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    Vector3 centerPos;
    private bool done = false;
    protected override Status OnStart()
    {
        centerPos = new Vector3(0, 2, 0);
        Self.Value.transform.DOMove(centerPos, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            done = true;
        });
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (done) return Status.Success;

        else return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

