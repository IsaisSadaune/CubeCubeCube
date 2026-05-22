using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MovingRackets", story: "[RacketLeft] or [RacketRight] Moves at EndPos", category: "Action", id: "daa110d21a5c23659455eb6ab5f05449")]
public partial class MovingRacketsAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> RacketLeft;
    [SerializeReference] public BlackboardVariable<GameObject> RacketRight;
    RetroBoss boss;
    bool done;
    protected override Status OnStart()
    {
        done = false;
        boss = RetroBoss.Instance;

        if(boss.pongEndPos.transform.position.x > 0)
            RacketLeft.Value.transform.DOMoveZ(boss.pongEndPos.transform.position.z, 0.2f).SetEase(Ease.InOutQuad).OnComplete(() =>
            {
                done = true;
            });
        else
            RacketRight.Value.transform.DOMoveZ(boss.pongEndPos.transform.position.z, 0.2f).SetEase(Ease.InOutQuad).OnComplete(() =>
            {
                done = true;
            });

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (done) return Status.Success;

        else return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

