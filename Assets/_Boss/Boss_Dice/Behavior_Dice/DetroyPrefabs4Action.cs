using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DetroyPrefabs4", story: "[ListCopies4] get removed", category: "Action", id: "58b5f646906d86a7ad592b720f22adf3")]
public partial class DetroyPrefabs4Action : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> ListCopies4;

    //Variables modifiables
    private float distanceToMove = ConstantsDice.distanceToMoveOut4;
    private float timeToMove = ConstantsDice.timeToMoveOut4;
    private float timeToDie = ConstantsDice.timeToDie4;
    private Ease easeOut = Ease.OutBounce;


    private bool hasStartedDestroying;
    private List<Sequence> sequences;


    protected override Status OnStart()
    {
        sequences = new();
        hasStartedDestroying = false;
        DOVirtual.DelayedCall(ConstantsDice.timeBeforeRemoving, () =>
        {
            hasStartedDestroying = true;
            foreach (var item in ListCopies4.Value)
            {
                Sequence s = DOTween.Sequence();
                s.Append(item.transform.DOMoveY(item.transform.position.y - item.transform.up.y * distanceToMove, timeToMove).SetEase(easeOut));
                s.Append(item.transform.DOScale(Vector3.zero, timeToDie));
                s.OnComplete(() => MonoBehaviour.Destroy(item.gameObject));
                sequences.Add(s);
            }
        });

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (sequences.All(x => !x.IsPlaying()) && hasStartedDestroying == true)
            return Status.Success;
        return Status.Running;
    }
}

