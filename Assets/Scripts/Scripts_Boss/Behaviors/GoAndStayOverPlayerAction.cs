using DG.Tweening;
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GoAndStayOverPlayer", story: "[Boss] goes and stay over [Player]", category: "Action", id: "7a9a9c2432726a8e4fa8c8805cb27e20")]
public partial class GoAndStayOverPlayerAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Boss;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    private Tween t;
    private bool timePassed = false;


    private float distancePlayerBoss = 25f;
    private float timeBeforeThwomp = 1f;

    protected override Status OnStart()
    {
        timePassed = false;
        Boss.Value.transform.position = Player.Value.transform.position + Vector3.up * distancePlayerBoss;
        Awaitable a = TimerBeforeFalling();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (timePassed)
            return Status.Success;
        Boss.Value.transform.position = Player.Value.transform.position + Vector3.up * distancePlayerBoss;
        return Status.Running;
    }


    protected override void OnEnd()
    {
        Debug.Log("FIN");
    }



    private async Awaitable TimerBeforeFalling()
    {
        await Awaitable.WaitForSecondsAsync(timeBeforeThwomp);
        timePassed = true;
    }
}

