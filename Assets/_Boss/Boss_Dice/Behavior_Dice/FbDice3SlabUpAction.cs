using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FbDice3SlabUp", story: "move up [Slab]", category: "Action", id: "8cdfb3264fc50b0a8886579cb05901bb")]
public partial class FbDice3SlabUpAction : Action
{
    [SerializeReference] public BlackboardVariable<FbSlabManager> Slab;

    protected override Status OnStart()
    {
        Slab.Value.SlabComeBack();
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

