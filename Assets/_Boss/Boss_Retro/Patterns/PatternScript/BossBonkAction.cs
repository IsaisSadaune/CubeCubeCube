using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "BossBonk", story: "[Self] move to EndPos at [Speed]", category: "Action", id: "8d1969e33ad8f2f24d37c5c9e53218c3")]
public partial class BossBonkAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<float> Speed;

    protected override Status OnStart()
    {
        if(RetroBoss.Instance.bonk <= 5)
            Speed.Value = Speed.Value - (RetroBoss.Instance.bonk / 10); 
        Self.Value.transform.DOMove(RetroBoss.Instance.pongEndPos.transform.position, 1f).SetEase(Ease.Linear);
        

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

