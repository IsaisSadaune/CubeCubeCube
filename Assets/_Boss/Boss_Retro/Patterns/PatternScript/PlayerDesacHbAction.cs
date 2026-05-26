using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "playerDesacHB", story: "Desactivate [Player] Hitbox", category: "Action", id: "20aa851e71b34e3ef0c9afed03df486a")]
public partial class PlayerDesacHbAction : Action
{
    [SerializeReference] public BlackboardVariable<Player> Player;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {

        Player.Value.hitbox.enabled = false;
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

