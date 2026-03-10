using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetActiveRackets", story: "Set Active [RacketRight] and [RacketLeft]", category: "Action", id: "c4c9e82c8e6d60e8dae3a4a123cfc651")]
public partial class SetActiveRacketsAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> RacketRight;
    [SerializeReference] public BlackboardVariable<GameObject> RacketLeft;

    protected override Status OnStart()
    {
        RacketLeft.Value.SetActive(true);
        RacketRight.Value.SetActive(true);
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

