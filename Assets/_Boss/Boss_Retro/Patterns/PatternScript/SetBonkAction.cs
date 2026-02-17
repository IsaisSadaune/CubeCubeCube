using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetBonk", story: "Set [Bonk] +1", category: "Action", id: "2f9517b4647ed6d16a8013cc174190dd")]
public partial class SetBonkAction : Action
{
    [SerializeReference] public BlackboardVariable<int> Bonk;

    protected override Status OnStart()
    {
        Bonk.Value++;
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

