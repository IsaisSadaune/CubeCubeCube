using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dice2_RespawnAt", story: "[Boss] come back [here]", category: "Action", id: "0bb944bd1e82a3044efe7cde7148e2db")]
public partial class Dice2RespawnAtAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Boss;
    [SerializeReference] public BlackboardVariable<Transform> Here;
    private Tween t;

    private float timeToSpawnBoss2 = ConstantsDice.timeToSpawnBoss2;

    protected override Status OnStart()
    {
        Boss.Value.transform.position = Here.Value.position;
        t = Boss.Value.transform.DOScale(1, timeToSpawnBoss2);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(!t.IsPlaying())
            return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

