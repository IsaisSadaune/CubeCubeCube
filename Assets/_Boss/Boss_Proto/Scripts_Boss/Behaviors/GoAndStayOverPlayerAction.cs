using DG.Tweening;
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GoAndStayOverPlayer", story: "[Boss] reapear in [timeToReapear] goes and stay over [Player] for [timeOverPlayer]", category: "Action", id: "7a9a9c2432726a8e4fa8c8805cb27e20")]
public partial class GoAndStayOverPlayerAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Boss;
    [SerializeReference] public BlackboardVariable<float> TimeToReapear;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<float> TimeOverPlayer;
    private Tween t;
    private bool timePassed = false;


    private float distancePlayerBoss = 20f;

    protected override Status OnStart()
    {

        timePassed = false;
        Boss.Value.transform.DOScale(Vector3.one, TimeToReapear.Value);
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
        await Awaitable.WaitForSecondsAsync(TimeOverPlayer.Value);
        timePassed = true;
    }
}

