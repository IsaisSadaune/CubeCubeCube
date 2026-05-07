using MoreMountains.Feedbacks;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Unity.VisualScripting;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Phase Transition", story: "Play [PhaseTransitionFeedbacks]", category: "Action", id: "6acb5cc64e482870d6c036fec6c74a43")]
public partial class PhaseTransitionAction : Action
{
    [SerializeReference] public BlackboardVariable<MMF_Player> PhaseTransitionFeedbacks;

    protected override Status OnStart()
    {
        PhaseTransitionFeedbacks.Value.PlayFeedbacks();
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

