using DG.Tweening;
using MoreMountains.Feedbacks;
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GoToDestionation", story: "[Self] goes to [Destination] squarely at [speed] speed, also place [feedback]", category: "Action", id: "129a8c0a2445684181aa0d3c17da46c7")]
public partial class GoToDestionationAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Transform> Destination;
    [SerializeReference] public BlackboardVariable<float> Speed;
    [SerializeReference] public BlackboardVariable<GameObject> Feedback;
    Sequence tweenList;
    private float speed => Speed.Value;

    protected override Status OnStart()
    {
        Feedback.Value.SetActive(true);
        tweenList = DOTween.Sequence();

        if (!Mathf.Approximately(Destination.Value.transform.position.x, Self.Value.transform.position.x))
        { 
            tweenList.AppendCallback( () => Feedback.Value.transform.position = new Vector3(Destination.Value.transform.position.x, -2f, Self.Value.transform.position.z));

            tweenList.Append(Self.Value.transform.DOMoveX(Destination.Value.transform.position.x, 1f / speed)
                    .SetEase(Ease.InOutQuint));
        }
        if (!Mathf.Approximately(Destination.Value.transform.position.z, Self.Value.transform.position.z))
        {
            tweenList.AppendCallback(() => Feedback.Value.transform.position = new Vector3(Self.Value.transform.position.x, -2f, Destination.Value.transform.position.z));
            tweenList.Append(Self.Value.transform.DOMoveZ(Destination.Value.transform.position.z, 1f / speed)
                .SetEase(Ease.InOutQuint));
            }
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

    protected override void OnEnd()
    {
        Feedback.Value.SetActive(false);
    }

}

