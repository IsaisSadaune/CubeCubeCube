using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dice_SetToDestroyer", story: "[Variables] activate destroy", category: "Action", id: "cd69bfb9807f73783b40e435af2b353f")]
public partial class DiceSetToDestroyerAction : Action
{
    [SerializeReference] public BlackboardVariable<Boss_Variables> Variables;

    protected override Status OnStart()
    {
        Variables.Value.SetHardDestroying();
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

