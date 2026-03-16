using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetFeedbackUnderBoss", story: "[Feedback] GoTo [Position] but grounded", category: "Action", id: "33bc036f000dbeb38e26e43fc3ef15e5")]
public partial class SetFeedbackUnderBossAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Feedback;
    [SerializeReference] public BlackboardVariable<Transform> Position;

    protected override Status OnStart()
    {
        Physics.Raycast(Position.Value.transform.position, Vector3.down, out RaycastHit r);
        Feedback.Value.transform.position = r.point;
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

