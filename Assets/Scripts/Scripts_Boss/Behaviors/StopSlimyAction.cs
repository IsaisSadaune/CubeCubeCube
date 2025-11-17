using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "StopSlimy", story: "[Self] stop Slimy", category: "Action", id: "943ac544586516f2c4c6146d526b0b76")]
public partial class StopSlimyAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Boss_Variables bv = Self.Value.GetComponent<Boss_Variables>();
        bv.StopSlimy();
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

