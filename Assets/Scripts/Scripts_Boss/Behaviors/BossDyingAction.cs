using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "BossDying", story: "Boss Wont Do Anything Permanently", category: "Action", id: "3045e43df42764c6baf7a93f197d8b24")]
public partial class BossDyingAction : Action
{

    protected override Status OnStart()
    {
        DOTween.KillAll();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Debug.Log("ping");
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

