using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FruitSpawn", story: "[Fruit] Spawn at [Position]", category: "Action", id: "d92eee975be5e0c3280afe3db9b7daa5")]
public partial class FruitSpawnAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Fruit;
    [SerializeReference] public BlackboardVariable<Transform> Position;

    protected override Status OnStart()
    {
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

