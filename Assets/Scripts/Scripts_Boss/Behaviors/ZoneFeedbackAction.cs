using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Zone Feedback", story: "Set [Feedback] at [Position] or [Center] for [Time]", category: "Action", id: "14ed6b36d31cbbbb78c9e62d8045636a")]
public partial class ZoneFeedbackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Feedback;
    [SerializeReference] public BlackboardVariable<Transform> Position;
    [SerializeReference] public BlackboardVariable<Transform> Center;
    [SerializeReference] public BlackboardVariable<float> Time;
    private Awaitable timerFb;

    protected override Status OnStart()
    {
        if (Position.Value.TryGetComponent<Player>(out Player p))
            if(p.hasFalledRecently)
                Feedback.Value.transform.position = Center.Value.transform.position;
            else
                Feedback.Value.transform.position = Position.Value.transform.position;
        else
                Feedback.Value.transform.position = Position.Value.transform.position;
        Feedback.Value.SetActive(true);
        timerFb = SpikeTimer();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
    private async Awaitable SpikeTimer()
    {
        await Awaitable.WaitForSecondsAsync(Time.Value);
        Feedback.Value.SetActive(false);
    }
}

