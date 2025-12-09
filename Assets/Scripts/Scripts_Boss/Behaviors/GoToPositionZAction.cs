using DG.Tweening;
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GoToPositionZ", story: "[Self] goes at [DestinationZ] Z in [X] seconds", category: "Action", id: "66c65b7eb9bfc08d611457ebe9c988eb")]
public partial class GoToPositionZAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Transform> DestinationZ;
    [SerializeReference] public BlackboardVariable<float> X;
    Tween t;

    protected override Status OnStart()
    {
        t = Self.Value.transform.DOMoveZ(DestinationZ.Value.transform.position.z, 1f / X).SetEase(Ease.InOutQuint);
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

