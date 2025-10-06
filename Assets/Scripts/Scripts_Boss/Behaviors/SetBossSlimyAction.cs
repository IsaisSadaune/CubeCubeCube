using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set Boss Slimy", story: "[Self] becomes Slimy for [x] Seconds", category: "Action", id: "97cbf6cca85b9a1de987b9caf4343e66")]
public partial class SetBossSlimyAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<float> X;
    private Awaitable timerSlime;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Self.Value.GetComponent<Boss_Variables>().SetSlimy();
        timerSlime = SpikeTimer();
        return Status.Success;
    }

    private async Awaitable SpikeTimer()
    {
        await Awaitable.WaitForSecondsAsync(X.Value);
        Self.Value.GetComponent<Boss_Variables>().StopSlimy();
    }
}

