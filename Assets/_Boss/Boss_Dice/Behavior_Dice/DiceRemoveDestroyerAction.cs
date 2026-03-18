using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dice_RemoveDestroyer", story: "[Dice] remove destroy", category: "Action", id: "e910f51f714ade2cf03ad18d52f48df7")]
public partial class DiceRemoveDestroyerAction : Action
{
    [SerializeReference] public BlackboardVariable<Boss_Variables> Dice;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Dice.Value.StopHardDestroying();
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

