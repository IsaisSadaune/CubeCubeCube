using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dice3_Jump", story: "[Dice] Jumps to [Position]", category: "Action", id: "fff25d0f2b9185c66d43866460533136")]
public partial class Dice3JumpAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Dice;
    [SerializeReference] public BlackboardVariable<Transform> Position;

    private Tween t;

    private float jumpPower = ConstantsDice.jumpPower;
    private float duration = ConstantsDice.duration;


    protected override Status OnStart()
    {
        t = Dice.Value.transform.DOJump(Position.Value.transform.position, jumpPower, 1, duration).SetEase(Ease.InExpo).SetUpdate(UpdateType.Fixed);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(!t.IsPlaying()) return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

