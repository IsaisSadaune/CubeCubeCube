using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Cube3Falls", story: "[InstanceClone] [InstanceClone2] and [Boss1] fall for [timeToFall]", category: "Action", id: "7b449d55789cf17806b0f2c989b6e4b2")]
public partial class Cube3FallsAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> InstanceClone;
    [SerializeReference] public BlackboardVariable<GameObject> InstanceClone2;
    [SerializeReference] public BlackboardVariable<GameObject> Boss1;
    [SerializeReference] public BlackboardVariable<float> TimeToFall;

    private Sequence s;
    protected override Status OnStart()
    {
        s = DOTween.Sequence();
        s.Join(InstanceClone.Value.transform.DOMoveY(-15f, TimeToFall.Value));
        s.Join(InstanceClone2.Value.transform.DOMoveY(-15f, TimeToFall.Value));
        s.Join(Boss1.Value.transform.DOMoveY(0f, TimeToFall.Value));

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

