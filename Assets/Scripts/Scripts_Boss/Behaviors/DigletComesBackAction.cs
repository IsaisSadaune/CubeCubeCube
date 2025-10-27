using DG.Tweening;
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DigletComesBack", story: "[Self] goes back under [Player]", category: "Action", id: "d29e604d85131e95920a84f0f9c8f4ba")]
public partial class DigletComesBackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    Tween t;
    private float speed = 2f;
    protected override Status OnStart()
    {

        t = Self.Value.transform.DOMove(Player.Value.transform.position + Vector3.down * 8f, 1f / speed).
            OnComplete(() =>
            {
                t = Self.Value.transform.DOMoveY(0, 1f / speed)
                .SetEase(Ease.InOutQuint)
                .SetDelay(0.5f);
            });

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (!t.IsPlaying()) return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
        Self.Value.GetComponent<Boss_Variables>().StopDestroying();
    }
}

