using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "boss3rework", story: "[Boss1] goes shwump", category: "Action", id: "8ce453932508c1f3d51cdf97c00b5945")]
public partial class Boss3ReworkAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Boss1;
    Sequence s;
    protected override Status OnStart()
    {
        s = DOTween.Sequence();
        s.Append(Boss1.Value.transform.DOScaleY(0.25f, 0.25f));
        s.Join(Boss1.Value.transform.DOScaleX(2f, 0.25f));
        s.Join(Boss1.Value.transform.DOScaleZ(2f, 0.25f));

        s.Append(Boss1.Value.transform.DOScaleY(1f, 0.25f)).SetEase(Ease.OutQuint);
        s.Join(Boss1.Value.transform.DOScaleX(1f, 0.25f)).SetEase(Ease.OutQuint);
        s.Join(Boss1.Value.transform.DOScaleZ(1f, 0.25f)).SetEase(Ease.OutQuint);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(!s.IsPlaying())
            return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

