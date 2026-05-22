using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[GeneratePropertyBag]
[NodeDescription(name: "ChoseAPosition", story: "[Self] assign a [directionLeft] or [directionRight] to endPosition", category: "Action", id: "dcf5f31236ff1dce657e6043255704bd")]
public partial class ChoseAPositionAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<List<GameObject>> DirectionLeft;
    [SerializeReference] public BlackboardVariable<List<GameObject>> DirectionRight;
    RetroBoss boss;
    protected override Status OnStart()
    {
        boss = Self.Value.GetComponent<RetroBoss>();
        if(DirectionLeft.Value.Contains(boss.pongEndPos))
        {
            int rdm = Random.Range(0, DirectionRight.Value.Count);
            boss.pongEndPos = DirectionRight.Value[rdm];
        }
        else
        {
            int rdm = Random.Range(0, DirectionLeft.Value.Count);
            boss.pongEndPos = DirectionLeft.Value[rdm];
        }
        Debug.Log(boss.pongEndPos);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(boss.pongEndPos != null)
        {
            boss.bonk++;
            return Status.Success;
        }
        else
            return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

