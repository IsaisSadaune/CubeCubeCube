using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dice2_ChosePosBoss", story: "Chose [Pos] for [Boss] in [posParent]", category: "Action", id: "015842c4f54ae7c03d58e51272cce48b")]
public partial class Dice2ChosePosBossAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Pos;
    [SerializeReference] public BlackboardVariable<GameObject> Boss;
    [SerializeReference] public BlackboardVariable<GameObject> PosParent;

    protected override Status OnStart()
    {
        Pos.Value = GetRandomPos();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }

    private Transform GetRandomPos() => PosParent.Value.transform.GetChild(UnityEngine.Random.Range(0, PosParent.Value.transform.childCount));
}

