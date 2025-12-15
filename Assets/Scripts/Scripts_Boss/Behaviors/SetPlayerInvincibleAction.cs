using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetPlayerInvincible", story: "[Player] becomes invincible", category: "Action", id: "efae48413c3afaa9ab49adfa0ff0a59f")]
public partial class SetPlayerInvincibleAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Player;

    protected override Status OnStart()
    {
        Player.Value.GetComponent<Player>().iFraming = true;
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

