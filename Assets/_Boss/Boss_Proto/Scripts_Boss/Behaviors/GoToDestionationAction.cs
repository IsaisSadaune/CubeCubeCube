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
    Vector3 BossPosition => Self.Value.transform.position;
    Vector3 DestinationPosition;

    private float speed => Speed.Value;

    protected override Status OnStart()
    {
        DestinationPosition = Destination.Value.transform.position;
        Feedback.Value.SetActive(true);
        tweenList = DOTween.Sequence();

        //verifie si le boss est proche de la position x voulue. Si oui, ne se déplace pas
        if (!Mathf.Approximately(DestinationPosition.x, BossPosition.x))
        { 
            tweenList.AppendCallback( () => Feedback.Value.transform.position = new Vector3(DestinationPosition.x, -2f, BossPosition.z));

            tweenList.Append(Self.Value.transform.DOMoveX(DestinationPosition.x, 1f / speed)
                    .SetEase(Ease.InOutQuint));
        }
        //pareil en z
        if (!Mathf.Approximately(DestinationPosition.z, BossPosition.z))
        {
            tweenList.AppendCallback(() => Feedback.Value.transform.position = new Vector3(BossPosition.x, -2f, DestinationPosition.z));
            tweenList.Append(Self.Value.transform.DOMoveZ(DestinationPosition.z, 1f / speed)
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

