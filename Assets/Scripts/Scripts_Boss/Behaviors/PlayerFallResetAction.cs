using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PlayerFallReset", story: "[Player] Fall Reset", category: "Action", id: "af4b57c1bfe7bf741cb945a80da6561e")]
public partial class PlayerFallResetAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Player;

    protected override Status OnStart()
    {
        Player.Value.GetComponent<Player>().hasFalledRecently = false;
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

