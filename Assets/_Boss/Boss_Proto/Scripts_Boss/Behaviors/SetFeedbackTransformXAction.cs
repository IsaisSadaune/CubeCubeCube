using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetFeedbackTransformX", story: "[Self] [Feedback] goes to [Position] X", category: "Action", id: "bec3c85285c08085297f085e315b07b6")]
public partial class SetFeedbackTransformXAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Feedback;
    [SerializeReference] public BlackboardVariable<Transform> Position;
    Awaitable timerFb;
    protected override Status OnStart()
    {
        Feedback.Value.transform.position = new Vector3(
            Position.Value.transform.position.x,
            -2f,
            Self.Value.transform.position.z);
        Feedback.Value.SetActive(true);
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

