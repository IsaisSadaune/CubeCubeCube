using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveRacketsOut", story: "Move [RacketLeft] and [RacketRight] out of the Arena and set [RacketsUp]", category: "Action", id: "f9bff10d071b8274f2c527e0ae587abe")]
public partial class MoveRacketsOutAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> RacketLeft;
    [SerializeReference] public BlackboardVariable<GameObject> RacketRight;
    [SerializeReference] public BlackboardVariable<bool> RacketsUp;
    protected override Status OnStart()
    {
        if(RacketLeft.Value.activeSelf)
        {
            RacketLeft.Value.transform.DOMoveY(-11, 1f).SetEase(Ease.InOutQuad);
            RacketRight.Value.transform.DOMoveY(15, 1f).SetEase(Ease.InOutQuad).OnComplete(()
            =>{RacketsUp.Value = false;});
        }
        
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

