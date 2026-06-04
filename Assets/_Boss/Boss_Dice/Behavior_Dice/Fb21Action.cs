using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Fb2_1", story: "Activate Feedback on [slab]", category: "Action", id: "cc87483f608a767ffb9b7a6f757ca12a")]
public partial class Fb21Action : Action
{
    [SerializeReference] public BlackboardVariable<FbSlabManager> Slab;

    protected override Status OnStart()
    {
        Slab.Value.ChangeColorSlab2_1();
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

