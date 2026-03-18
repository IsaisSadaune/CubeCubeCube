using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RemoveAesthetic", story: "[Aesthetic] is removed", category: "Action", id: "aa7b31f89c91f2e4a732fd2e617ab4f3")]
public partial class RemoveAestheticAction : Action
{
    [SerializeReference] public BlackboardVariable<AestheticManager> Aesthetic;

    protected override Status OnStart()
    {
        Aesthetic.Value.ComeBack();
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

