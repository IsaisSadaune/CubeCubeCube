using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;
using System.Collections.Generic;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MovingRackets", story: "[RacketLeft] or [RacketRight] Moves at EndPos depending on [PongPositionsLeft] and [PongPositionsRight]", category: "Action", id: "daa110d21a5c23659455eb6ab5f05449")]
public partial class MovingRacketsAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> RacketLeft;
    [SerializeReference] public BlackboardVariable<GameObject> RacketRight;
    [SerializeReference] public BlackboardVariable<List<GameObject>> PongPositionsLeft;
    [SerializeReference] public BlackboardVariable<List<GameObject>> PongPositionsRight;
    RetroBoss boss;
    bool done;
    protected override Status OnStart()
    {
        done = false;
        boss = RetroBoss.Instance;

        if(PongPositionsRight.Value.Contains(boss.pongEndPos))
            RacketLeft.Value.transform.DOMoveZ(boss.pongEndPos.transform.position.z, 0.2f).SetEase(Ease.InOutQuad).OnComplete(() =>
            {
                RacketLeft.Value.GetComponentInChildren<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
                RacketRight.Value.GetComponentInChildren<MeshRenderer>().material.SetColor("_EmissionColor", Color.red);
                done = true;
            });
        else if(PongPositionsLeft.Value.Contains(boss.pongEndPos))
            RacketRight.Value.transform.DOMoveZ(boss.pongEndPos.transform.position.z, 0.2f).SetEase(Ease.InOutQuad).OnComplete(() =>
            {
                RacketLeft.Value.GetComponentInChildren<MeshRenderer>().material.SetColor("_EmissionColor", Color.red);
                RacketRight.Value.GetComponentInChildren<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
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

