using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DetroyPrefabs4", story: "[ListCopies4] get removed", category: "Action", id: "58b5f646906d86a7ad592b720f22adf3")]
public partial class DetroyPrefabs4Action : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> ListCopies4;

    //Variables modifiables
    private float distanceToMove = 5f;
    private float timeToMove = 1f;
    private float timeToDie = 0.5f;

    private List<Sequence> sequences;

    protected override Status OnStart()
    {
        sequences = new();

        foreach(var item in ListCopies4.Value)
        {
            Sequence s = DOTween.Sequence();
            s.Append(item.transform.DOMoveY(item.transform.position.y - item.transform.up.y * distanceToMove, timeToMove));
            s.Append(item.transform.DOScale(Vector3.zero, timeToDie));
            s.OnComplete(() => MonoBehaviour.Destroy(item.gameObject));
            sequences.Add(s);
        }

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(sequences.All( x => !x.IsPlaying()))
            return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

