using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Reset Ground", story: "[Ground] gets reset", category: "Action", id: "2f0bec1367f3b1a44f8c9a2adfb4f0a8")]
public partial class ResetGroundAction : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> Ground;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        foreach (var g in Ground.Value)
        {
            SlabController s = g.GetComponent<SlabController>();
            if (s.hardDisparition) s.HardApparition();
        }

        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

