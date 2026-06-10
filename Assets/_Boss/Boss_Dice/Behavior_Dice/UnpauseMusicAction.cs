using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "UnpauseMusic", story: "Unpause Music and stop transiPhase sound", category: "Action", id: "7805358b8d3feb001537d3aa1dc70c5f")]
public partial class UnpauseMusicAction : Action
{

    protected override Status OnStart()
    {
        AudioManager.Instance.SoundStop("TransiPhase");
        AudioManager.Instance.UnpauseMusic();
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

