using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetFeedbackZ", story: "[Self] [Feedback] goes to [DestinationZ] Z", category: "Action", id: "f887cb1c488380bcdf02e18a35fac825")]
public partial class SetFeedbackZAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Feedback;
    [SerializeReference] public BlackboardVariable<Transform> DestinationZ;
    Awaitable timerFb;
    protected override Status OnStart()
    {
        Feedback.Value.transform.position = new Vector3(
            Self.Value.transform.position.x, 
            -2f, 
            DestinationZ.Value.transform.position.z);
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

