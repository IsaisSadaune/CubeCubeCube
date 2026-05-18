using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "TutoUp", story: "[Boss] goes Up", category: "Action", id: "6e097b194a2a34b3876bdb7333932b86")]
public partial class TutoUpAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Boss;
    private Tween t;
    protected override Status OnStart()
    {
        t = Boss.Value.transform.DOMoveY(25f, 1.5f);
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

