using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dice3FeedbackBoss", story: "Shwomp [model]", category: "Action", id: "95d81d29765e1a8ed06ece0ea670dc7c")]
public partial class Dice3FeedbackBossAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Model;

    protected override Status OnStart()
    {
        Vector3 v = Model.Value.transform.localScale;
        Tween t = Model.Value.transform.DOScaleY(v.y * 0.5f, 0.1f)
            .SetEase(Ease.InBounce);
        t.OnComplete( () => Model.Value.transform.DOScale(v, 0.1f));
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

