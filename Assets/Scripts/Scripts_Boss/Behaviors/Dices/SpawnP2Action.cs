using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Spawn P2", story: "[Boss1] reset Health, [Boss2] Spawns", category: "Action", id: "9735c1fad6acaeeb9fdd237a744a13d0")]
public partial class SpawnP2Action : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Boss1;
    [SerializeReference] public BlackboardVariable<GameObject> Boss2;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Boss2.Value.SetActive(true);
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

