using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "use Spikes", story: "use [Spines] then retract them", category: "Action", id: "68bb3c8fa8b75995142864ce36b75945")]
public partial class UseSpikesAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Spines;
    private Awaitable timer;
    protected override Status OnStart()
    {
        timer = SpikeTimer();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(timer.IsCompleted) return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }

    private async Awaitable SpikeTimer()
    {
        await Awaitable.WaitForSecondsAsync(1f);
        Spines.Value.SetActive(true);
        await Awaitable.WaitForSecondsAsync(1f);
        Spines.Value.SetActive(false);
    }
}

