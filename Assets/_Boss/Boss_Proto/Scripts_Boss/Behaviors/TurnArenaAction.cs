using System;
using DG.Tweening;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Net.NetworkInformation;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "TurnArena", story: "[Self] Turn the [Arena] and the [Player]", category: "Action", id: "7afcdfea5313a32ddb3a45298752b6d6")]
public partial class TurnArenaAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Arena;
    [SerializeReference] public BlackboardVariable<GameObject> player;
    private bool done = false;

    protected override Status OnStart()
    {
        player.Value.transform.SetParent(Arena.Value.transform);
        Arena.Value.transform.DORotate(new Vector3(0, 90, 0), 2f).OnComplete(() => 
        {
            player.Value.transform.SetParent(null);
            done = true;
        });
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(done)
        {
            return Status.Success;
        }
        else
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

