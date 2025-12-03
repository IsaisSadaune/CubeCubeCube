using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections.Generic;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "BossShockwaves", story: "Spawn [Shockwaves] at [Self]", category: "Action", id: "05205d6bead9bcc16aa6329f7587a019")]
public partial class BossShockwavesAction : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> Shockwaves;
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        foreach (var item in Shockwaves.Value)
        {
            GameObject.Instantiate(item, Self.Value.transform.position + Vector3.down*2.5f, item.transform.rotation);
        }
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

