using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Self goes to BonusFruit", story: "[Self] goes to [BonusFruit] by moving only on z or x at [Speed]", category: "Action", id: "b7aa297dc22391c819c56e2236f7e1dc")]
public partial class SelfGoesToBonusFruitAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> BonusFruit;
    [SerializeReference] public BlackboardVariable<float> Speed;

    private bool done;
    protected override Status OnStart()
    {
        done = false;
        float dx = Self.Value.transform.position.x - BonusFruit.Value.transform.position.x;
        float dz = Self.Value.transform.position.z - BonusFruit.Value.transform.position.z;

        float durationX = Mathf.Abs(dx) / Speed.Value / 20;
        float durationZ = Mathf.Abs(dz) / Speed.Value / 20;

        if (Mathf.Abs(dx) >= Mathf.Abs(dz) && dx != 0)
        {
            Self.Value.transform.DOMoveX(BonusFruit.Value.transform.position.x, durationX).SetEase(Ease.Linear)
            .OnComplete(() => Self.Value.transform.DOMoveZ(BonusFruit.Value.transform.position.z, durationZ).SetEase(Ease.Linear)
            .OnComplete(() => done = true));
        }
        else if (dz != 0)
        {
            Self.Value.transform.DOMoveZ(BonusFruit.Value.transform.position.z, durationZ).SetEase(Ease.Linear)
            .OnComplete(() => Self.Value.transform.DOMoveX(BonusFruit.Value.transform.position.x, durationX).SetEase(Ease.Linear)
            .OnComplete(() => done = true));
        }
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(done)
            return Status.Success;
        else
            return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

