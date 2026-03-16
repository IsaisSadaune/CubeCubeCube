using DG.Tweening;
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ThrowDice", story: "Throw [Dice]", category: "Action", id: "b43ce9a96eed0717564a515de3661f05")]
public partial class ThrowDiceAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Dice;
    private Sequence t;
    protected override Status OnStart()
    {
        Vector3 rotationVector = new Vector3(UnityEngine.Random.Range(180f, 360f), UnityEngine.Random.Range(0f, 180f), UnityEngine.Random.Range(0f, 360f));

        t = DOTween.Sequence();
        t.Append(Dice.Value.transform.DOMoveY(20, 3))
            .Join(Dice.Value.transform.DOBlendablePunchRotation(rotationVector, 2f))
         .Append(Dice.Value.transform.DOMoveY(0, 1))
            .SetEase(Ease.InQuint);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (!t.IsPlaying())
            return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

