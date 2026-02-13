using DG.Tweening;
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DigletComesBack", story: "[Self] goes back under [Player] or go at [center] if he can't", category: "Action", id: "d29e604d85131e95920a84f0f9c8f4ba")]
public partial class DigletComesBackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<Transform> Center;
    Tween t;
    private float speed = 5f;
    protected override Status OnStart()
    {
        Transform _location;
        if (Player.Value == null || !Player.Value.activeSelf || 
            Player.Value.GetComponent<Player>().hasFalledRecently) _location = Center.Value;
        else _location = Player.Value.transform;

            t = Self.Value.transform.DOMove(_location.transform.position + Vector3.down * 8f, 1f / speed).
                OnComplete(() =>
                {
                    t = Self.Value.transform.DOMoveY(0, 1f / speed)
                    .SetEase(Ease.InOutQuint)
                    .SetDelay(1f / speed);
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

