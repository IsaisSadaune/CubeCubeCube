using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "TutoSlide", story: "[Boss] Moves On [Player] Side", category: "Action", id: "4d476aab59e80a872f1945e22af67f0d")]
public partial class TutoSlideAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Boss;
    [SerializeReference] public BlackboardVariable<Player> Player;

    //Choose Left or Right
    //z = -116.7 ou z = -70.6

    //x mini = 404
    //x max = 424

    protected override Status OnStart()
    {
        float f = ClosestZofPlayer();

        Boss.Value.transform.position = new Vector3(ClampX(), -25f, ClosestZofPlayer());
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }

    public float ClosestZofPlayer()
    {
        float playerZ = Player.Value.transform.position.z;
        float distA = Mathf.Abs(playerZ - (-70.6f));
        float distB = Mathf.Abs(playerZ - (-116.7f));

        return distA < distB ? -70.6f : -116.7f;
    }

    public float ClampX()
    {
        if (Player.Value.transform.position.x > 424f)
            return 424f;
        else if (Player.Value.transform.position.x < 404f)
            return 404f;
        return Player.Value.transform.position.x;
    }
        
}

