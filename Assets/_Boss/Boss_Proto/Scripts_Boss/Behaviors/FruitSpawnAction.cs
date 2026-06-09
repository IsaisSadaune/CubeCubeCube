using System;
using System.Collections.Generic;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FruitSpawn", story: "[Fruit] Spawn at Position from [FruitPositions]", category: "Action", id: "d92eee975be5e0c3280afe3db9b7daa5")]
public partial class FruitSpawnAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Fruit;
    [SerializeReference] public BlackboardVariable<List<GameObject>> FruitPositions;
    protected override Status OnStart()
    {
        GameObject farthest = null;
        float maxDist = float.MinValue;

        foreach (GameObject pos in FruitPositions.Value)
        {
            float dist = Vector3.Distance(pos.transform.position, RetroBoss.Instance.transform.position);
            if (dist > maxDist)
            {
                maxDist = dist;
                farthest = pos;
            }
        }

        if (farthest != null)
            Fruit.Value.transform.position = farthest.transform.position;

        Fruit.Value.SetActive(true);
        AudioManager.Instance.PlaySound("Pacman Fruit");
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

