using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Self Jump", story: "[Self] jump and Rotate", category: "Action", id: "a132c4f6e9c8520e5f07ea41cb9bd261")]
public partial class SelfJumpAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    private bool done = false;
    protected override Status OnStart()
    {
        done = false;
        float currentY = Self.Value.transform.rotation.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0, currentY + 180, 0);

        Self.Value.transform.DORotateQuaternion(targetRotation, 1.5f);
        Self.Value.transform.DOMoveY(6f, 1.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            Self.Value.transform.DOMoveY(2f, 0.1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                done = true;
            });
        });
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
       if(done) return Status.Success;

       else return Status.Running;
    }

    protected override void OnEnd()
    {
    }

}

