using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections.Generic;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Put Bomb at Pos", story: "Put [BombList] at pos depending on [BombNbr]", category: "Action", id: "ee745270a558c3a6e11936f6e19f86de")]
public partial class PutBombAtPosAction : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> BombList;
    [SerializeReference] public BlackboardVariable<int> BombNbr;
    protected override Status OnStart()
    {
        RetroBoss.Instance.bombPattern(BombList.Value[BombNbr.Value]);
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

