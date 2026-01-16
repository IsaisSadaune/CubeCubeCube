using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "tmp_ActivateFbBoss", story: "[Self] activate [fbPlayerDeath]", category: "Action", id: "b5b7bd26ca623eba6d0980e436a1c829")]
public partial class TmpActivateFbBossAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> FbPlayerDeath;
    private Sequence tbag;
    private Transform t;
    protected override Status OnStart()
    {


        tbag = DOTween.Sequence();
        tbag
        .Append(Self.Value.transform.DOScaleY(0.5f, 0.15f)).SetEase(Ease.InBack)
        .Append(Self.Value.transform.DOScaleY(2f, 0.15f)).SetEase(Ease.OutBack)
        .SetLoops(-1, LoopType.Yoyo);

        FbPlayerDeath.Value.SetActive(true);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

