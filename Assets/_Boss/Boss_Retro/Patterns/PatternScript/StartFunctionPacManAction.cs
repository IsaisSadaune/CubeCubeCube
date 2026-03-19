using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "StartFunctionPacMan", story: "Start the Fucntion in the RetroBoss script", category: "Action", id: "92ef83432af1ef999016d14a23bdfa7e")]
public partial class StartFunctionPacManAction : Action
{
    protected override Status OnStart()
    {
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

