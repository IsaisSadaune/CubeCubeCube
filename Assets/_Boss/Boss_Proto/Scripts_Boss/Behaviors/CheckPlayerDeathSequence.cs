using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Composite = Unity.Behavior.Composite;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CheckPlayerDeath", story: "Execute while [Player] is alive", category: "Flow", id: "902ece0b54ee032684c0a034a83a3242")]
public partial class CheckPlayerDeathSequence : Composite
{
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public Node Playerisalive;
    [SerializeReference] public Node PlayerisDead;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(Player.Value != null)
            return Status.Success;
        return Status.Failure;
    }

    protected override void OnEnd()
    {
    }
}

