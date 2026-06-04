using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FbDice22", story: "Feedback activate on [pos1] [pos2] [pos3] [pos4] [pos5] [pos6]", category: "Action", id: "8996230f71ebf4f162a0b112fdeb388f")]
public partial class FbDice22Action : Action
{
    [SerializeReference] public BlackboardVariable<FbSlabManager> Pos1;
    [SerializeReference] public BlackboardVariable<FbSlabManager> Pos2;
    [SerializeReference] public BlackboardVariable<FbSlabManager> Pos3;
    [SerializeReference] public BlackboardVariable<FbSlabManager> Pos4;
    [SerializeReference] public BlackboardVariable<FbSlabManager> Pos5;
    [SerializeReference] public BlackboardVariable<FbSlabManager> Pos6;

    protected override Status OnStart()
    {
        Pos1.Value.ChangeColorSlab2_2();
        Pos2.Value.ChangeColorSlab2_2();
        Pos3.Value.ChangeColorSlab2_2();
        Pos4.Value.ChangeColorSlab2_2();
        Pos5.Value.ChangeColorSlab2_2();
        Pos6.Value.ChangeColorSlab2_2();
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

