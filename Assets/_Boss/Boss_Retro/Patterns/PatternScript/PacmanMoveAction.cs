using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PacmanMove", story: "[Self] goes to Player at [pacManSpeed]", category: "Action", id: "0abf40eb1663b98c293ee22584f5209a")]
public partial class PacmanMoveAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<float> PacManSpeed;

    bool done = false;
    Vector3 playerPos;
    protected override Status OnStart()
    {
        done = false;
        playerPos = Player.Instance.transform.position;

        float dx = Self.Value.transform.position.x - playerPos.x;
        float dz = Self.Value.transform.position.z - playerPos.z;

        float durationX = Mathf.Abs(dx) / PacManSpeed.Value;
        float durationZ = Mathf.Abs(dz) / PacManSpeed.Value;

        if(Mathf.Abs(dx) >= Mathf.Abs(dz) && dx != 0)
        {
            Self.Value.transform.DOMoveX(playerPos.x, durationX).SetEase(Ease.Linear).OnComplete(() =>
            {
                float newDz = Self.Value.transform.position.z - playerPos.z;
                float newDurationZ = Mathf.Abs(newDz) / PacManSpeed.Value;

                Self.Value.transform.DOMoveZ(playerPos.z, newDurationZ).SetEase(Ease.Linear).OnComplete(()=>
                {
                    done = true;
                });
            });
        }
        else if (dz != 0)
        {
            Self.Value.transform.DOMoveZ(playerPos.z, durationZ).SetEase(Ease.Linear).OnComplete(() =>
            {
                float newDx = Self.Value.transform.position.x - playerPos.x;
                float newDurationX = Mathf.Abs(newDx) / PacManSpeed.Value;

                Self.Value.transform.DOMoveX(playerPos.x, newDurationX).SetEase(Ease.Linear).OnComplete(()=>
                {
                    done = true;
                });
            });
        }
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(done) return Status.Success;

        else return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

