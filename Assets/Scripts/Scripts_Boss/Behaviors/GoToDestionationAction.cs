using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using DG.Tweening;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GoToDestionation", story: "[Self] goes to [Destination] squarely at [speed] speed", category: "Action", id: "129a8c0a2445684181aa0d3c17da46c7")]
public partial class GoToDestionationAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Transform> Destination;
    [SerializeReference] public BlackboardVariable<float> Speed;
    Sequence tweenList;
    private float speed => Speed.Value;

    protected override Status OnStart()
    {
        tweenList = DOTween.Sequence();
        tweenList
            .Append(Self.Value.transform.DOMoveX(Destination.Value.transform.position.x, 1f/speed).SetEase(Ease.InOutQuint))
            .Append(Self.Value.transform.DOMoveZ(Destination.Value.transform.position.z, 1f / speed).SetEase(Ease.InOutQuint));
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (!tweenList.IsPlaying())
        {
            Debug.Log("fin");
            return Status.Success;
        }
        return Status.Running;
    }

}

