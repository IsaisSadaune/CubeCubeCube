using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dice_Teleportation", story: "[Boss] teleport to [Position]", category: "Action", id: "5b7fff7eb3ae69f210bdb1e2cf135840")]
public partial class DiceTeleportationAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Boss;
    [SerializeReference] public BlackboardVariable<Transform> Position;

    private Sequence s;
    protected override Status OnStart()
    {
        s = DOTween.Sequence();
        s.Append(Boss.Value.transform.DOScale(Vector3.zero, 0.5f))
            .Append(Boss.Value.transform.DOMove(Position.Value.transform.position, 0.1f))
            .Append(Boss.Value.transform.DOScale(Vector3.one, 0.5f));
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(!s.IsPlaying())
            return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

