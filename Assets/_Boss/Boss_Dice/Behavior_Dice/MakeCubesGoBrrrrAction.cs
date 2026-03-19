using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MakeCubesGoBrrrr", story: "[ParentCubesRB] do their thing", category: "Action", id: "a6eb26194eed248c5acc735a1091917f")]
public partial class MakeCubesGoBrrrrAction : Action
{
    [SerializeReference] public BlackboardVariable<Recreator> ParentCubesRB;

    private Sequence s;
    protected override Status OnStart()
    {
        s = DOTween.Sequence();
        s = ParentCubesRB.Value.Top10CubeComebacks();
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

