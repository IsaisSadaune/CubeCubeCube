using MoreMountains.Feedbacks;
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dice3_ActivateMMF", story: "Activate Feedbacks from [Dalles1] [Dalles2] and [Dalles3]", category: "Action", id: "3d3cde5a854ec6165d0c4d71cd2ba8d4")]
public partial class Dice3ActivateMmfAction : Action
{
    [SerializeReference] public BlackboardVariable<FbSlabManager> Dalles1;
    [SerializeReference] public BlackboardVariable<FbSlabManager> Dalles2;
    [SerializeReference] public BlackboardVariable<FbSlabManager> Dalles3;
    protected override Status OnStart()
    {
        if(Dalles1.Value)
            Dalles1.Value.ChangeColorSlab();
        if (Dalles2.Value)
            Dalles2.Value.ChangeColorSlab();
        if(Dalles3.Value)
            Dalles3.Value.ChangeColorSlab();
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

