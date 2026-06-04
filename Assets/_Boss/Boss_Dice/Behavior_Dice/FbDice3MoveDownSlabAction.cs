using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FbDice3MoveDownSlab", story: "move down [slab]", category: "Action", id: "07abd84cc2a10a28a38174d6ad195dd7")]
public partial class FbDice3MoveDownSlabAction : Action
{
    [SerializeReference] public BlackboardVariable<FbSlabManager> Slab;

    protected override Status OnStart()
    {
        Slab.Value.SlabToGround();
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

