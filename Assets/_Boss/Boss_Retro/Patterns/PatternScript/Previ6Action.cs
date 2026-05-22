using DG.Tweening;
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "previ6", story: "[modelBoss1] feedback", category: "Action", id: "302dbd696ee61db5a6203daabe25dce6")]
public partial class Previ6Action : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> ModelBoss1;

    private Sequence s;
    protected override Status OnStart()
    {
        s = DOTween.Sequence();
        s.Append(ModelBoss1.Value.transform.DOScale(0.7f, 0.5f));
        s.Append(ModelBoss1.Value.transform.DOScale(1f, 0.25f).SetEase(Ease.OutElastic));
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

