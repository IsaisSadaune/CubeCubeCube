using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[GeneratePropertyBag]
[NodeDescription(name: "PatternPong", story: "[Self] assign a [directionLeft] or [directionRight] at [speed]", category: "Action", id: "dcf5f31236ff1dce657e6043255704bd")]
public partial class PatternPongAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<List<GameObject>> DirectionLeft;
    [SerializeReference] public BlackboardVariable<List<GameObject>> DirectionRight;
    [SerializeReference] public BlackboardVariable<float> Speed;
    float pong = 1.4f;
    int bonk;
    Tween t;
    Vector3 endPos;
    protected override Status OnStart()
    {
        if(Self.Value.transform.position.x < 0)
        {
            int rdm = Random.Range(0, DirectionRight.Value.Count);
            endPos = DirectionRight.Value[rdm].transform.position;
        }
        else
        {
            int rdm = Random.Range(0, DirectionLeft.Value.Count);
            endPos = DirectionLeft.Value[rdm].transform.position;
        }
        
        t = Self.Value.transform.DOMove(endPos, Speed.Value * pong).SetEase(Ease.Linear).OnComplete(() =>
        {
            if(pong >= 0.4f)
                pong -= 0.2f;

            bonk++;
        });
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(!t.IsPlaying() && bonk > 10)
        {
            pong = 1.4f;
            return Status.Success;
        }
        else if(!t.IsPlaying() && bonk <= 10)
            OnStart();
            
            return Status.Running;

    }

    protected override void OnEnd()
    {
    }
}

