using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Throw_Dice", story: "[Dice] get Thrown in the Air", category: "Action", id: "d2221df655941866e8839f5dca9d3d2a")]
public partial class ThrowDiceAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Dice;
    private Sequence t;
    protected override Status OnStart()
    {
        Vector3 rotationVector = new Vector3(UnityEngine.Random.Range(180f, 360f), UnityEngine.Random.Range(0f, 180f), UnityEngine.Random.Range(0f, 360f));

        t = DOTween.Sequence();
        t.Append(Dice.Value.transform.DOBlendablePunchRotation(rotationVector, 2f))
            .Join(Dice.Value.transform.DOMoveY(10,3))
            .Append(Dice.Value.transform.DOMoveY(0,1)
            .SetEase(Ease.InQuint));
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(!t.IsPlaying())
            return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

