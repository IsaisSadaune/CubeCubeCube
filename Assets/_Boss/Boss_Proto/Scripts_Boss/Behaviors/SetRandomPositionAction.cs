using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetRandomPosition", story: "Set [position4] at random", category: "Action", id: "e0908be73da90633634dd01f72c5dc3d")]
public partial class SetRandomPositionAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Position4;
    protected override Status OnStart()
    {

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

