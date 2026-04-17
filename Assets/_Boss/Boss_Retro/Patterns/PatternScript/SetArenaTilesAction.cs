using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.Rendering;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetArenaTiles", story: "Set [ArenaTiles] with [ArenaPrefab]", category: "Action", id: "44dd2e83652dce5b3d53404b1fbacf13")]
public partial class SetArenaTilesAction : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> ArenaTiles;
    [SerializeReference] public BlackboardVariable<GameObject> ArenaPrefab;

    protected override Status OnStart()
    {
        ArenaTiles.Value.Clear();
        for(int i = 0; i < ArenaPrefab.Value.transform.childCount; i++)
        {
            ArenaTiles.Value.Add(ArenaPrefab.Value.transform.GetChild(i).gameObject);
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

