using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set Boss Slimy", story: "[Self] becomes Slimy", category: "Action", id: "97cbf6cca85b9a1de987b9caf4343e66")]
public partial class SetBossSlimyAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Boss_Variables bv = Self.Value.GetComponent<Boss_Variables>();
        bv.SetSlimy();
        bv.ResetDetectors();
        return Status.Success;
    }
}