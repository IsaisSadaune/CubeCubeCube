using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Pause and Sound", story: "Pause Music and Play Sound", category: "Action", id: "52980b756ca7a79384175f208bbc8b65")]
public partial class PauseAndSoundAction : Action
{

    protected override Status OnStart()
    {
        AudioManager.Instance.PauseMusic();
        AudioManager.Instance.PlaySound("TransiPhase");
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

