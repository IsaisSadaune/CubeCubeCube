using DG.Tweening;
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Finish Thwomp", story: "[Self] fall for [timeToFall]", category: "Action", id: "85c4d16275fa241848b690c01baba5ec")]
public partial class FinishThwompAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<float> TimeToFall;

    private Sequence s;

    protected override Status OnStart()
    {
        s = DOTween.Sequence();

        s.Append(Self.Value.transform.DOMoveY(0, TimeToFall.Value)
            .SetEase(Ease.OutQuint));

        //s.Insert(TimeToFall.Value - 0.45f, Self.Value.transform.DOScaleY(0.25f, 0.25f));
        //s.Insert(TimeToFall.Value - 0.45f, Self.Value.transform.DOScaleX(2f, 0.25f));
        //s.Insert(TimeToFall.Value - 0.45f, Self.Value.transform.DOScaleZ(2f, 0.25f));

        //s.Append(Self.Value.transform.DOScaleY(1f, 0.25f)
        //    .SetEase(Ease.OutQuint));
        //s.Join(Self.Value.transform.DOScaleX(1f, 0.25f)
        //    .SetEase(Ease.OutQuint));
        //s.Join(Self.Value.transform.DOScaleZ(1f, 0.25f)
        //    .SetEase(Ease.OutQuint));

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (!s.IsPlaying())
            return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {

    }


}

