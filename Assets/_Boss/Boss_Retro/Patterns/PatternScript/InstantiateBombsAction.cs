using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections.Generic;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "InstantiateBombs", story: "Instantiate [BombNbr] [Bomb] and set [BombList]", category: "Action", id: "ee745270a558c3a6e11936f6e19f86de")]
public partial class InstantiateBombsAction : Action
{
    [SerializeReference] public BlackboardVariable<int> BombNbr;
    [SerializeReference] public BlackboardVariable<GameObject> Bomb;
    [SerializeReference] public BlackboardVariable<List<GameObject>> BombList;
    protected override Status OnStart()
    {
        BombList.Value.Clear();
        for(int i = 0; i < BombNbr; i++)
        {
            GameObject bomb = RetroBoss.Instance.bombPattern(Bomb.Value);
            BombList.Value.Add(bomb);
        }
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

