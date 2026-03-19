using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SwapStateObject", story: "[DiceBoss1Model] swap active", category: "Action", id: "43de67200dfd60ae3e5cbe0015bbdf39")]
public partial class SwapStateObjectAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> DiceBoss1Model;
    protected override Status OnStart()
    {

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (DiceBoss1Model?.Value == null)
        {
            LogFailure("DiceBoss1Model is not assigned in the Blackboard.");
            return Status.Failure;
        }
        DiceBoss1Model.Value.SetActive(!DiceBoss1Model.Value.activeSelf);
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

