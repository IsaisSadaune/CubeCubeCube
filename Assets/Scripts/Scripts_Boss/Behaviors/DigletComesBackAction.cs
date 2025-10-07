using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DigletComesBack", story: "[Self] goes back under [Player]", category: "Action", id: "d29e604d85131e95920a84f0f9c8f4ba")]
public partial class DigletComesBackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    Sequence s;

    protected override Status OnStart()
    {
        s = DOTween.Sequence();
        Self.Value.transform.position = Player.Value.transform.position + Vector3.down * 6f;
        s.AppendInterval(1f);
        s.Append(Self.Value.transform.DOMoveY(0, 1f).SetEase(Ease.InOutQuint));
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(!s.IsPlaying()) return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
        Self.Value.GetComponent<Boss_Variables>().StopDestroying();
    }
}

