using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "EndBattle", story: "Battle Ends", category: "Action", id: "6e5de750b0f2a7c62bd4841aacca8b15")]
public partial class EndBattleAction : Action
{

    protected override Status OnStart()
    {
        GameManager_Offi.Instance.EndBattle();
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

