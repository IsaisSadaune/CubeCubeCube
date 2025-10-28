using DG.Tweening;
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "use Spikes", story: "use [Spines] on [Self] then retract them", category: "Action", id: "68bb3c8fa8b75995142864ce36b75945")]
public partial class UseSpikesAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Spines;
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    private Awaitable timer;
    protected override Status OnStart()
    {
        timer = SpikeTimer();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (timer.IsCompleted) return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }

    private async Awaitable SpikeTimer()
    {
        await Awaitable.WaitForSecondsAsync(0.5f);
        Spines.Value.SetActive(true);
        Self.Value.transform.DOPunchScale(Vector3.one * 1.01f, 0.5f);
        await Awaitable.WaitForSecondsAsync(1f);
        Spines.Value.SetActive(false);
    }
}

