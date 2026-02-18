using System;
using System.Collections.Generic;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dice4GetPosition", story: "[Boss] saves [spawnPoints]", category: "Action", id: "3d8f2d335177530638cbb1ac7e704378")]
public partial class Dice4GetPositionAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Boss;
    [SerializeReference] public BlackboardVariable<List<Vector3>> SpawnPoints;






    protected override Status OnStart()
    {
        SpawnPoints.Value = new List<Vector3>();

        Vector3[] directions = new Vector3[]
        {
            Boss.Value.transform.forward,
            -Boss.Value.transform.forward,
            Boss.Value.transform.right,
            -Boss.Value.transform.right
        };

        foreach (var d in directions)
        {
            int i = 1;
            do
            {
                if (Physics.Raycast(Boss.Value.transform.position + d * i*10, Vector3.down))
                {
                    i++;
                }
                else i = -1;
                SpawnPoints.Value.Add(Boss.Value.transform.position + d * i*10);
            }
            while (i > 0);
        }




        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }


}

