using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;
using System.Linq;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dice4ThrowBlocs", story: "[Copies] are created at [ListPositions] in [ListCopies]", category: "Action", id: "9c4352c307b914b30af5a249a20aa7da")]
public partial class Dice4ThrowBlocsAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Copies;
    [SerializeReference] public BlackboardVariable<List<Vector3>> ListPositions;
    [SerializeReference] public BlackboardVariable<List<GameObject>> ListCopies;
    private List<Sequence> sList;
    private Ease easeIn = Ease.InBounce;

    //Variables modifiables
    private float distanceToMove = ConstantsDice.distanceToMoveIn4;
    private float timeToMove = ConstantsDice.timeToMoveIn4;
    private float timeToSpawn = ConstantsDice.timeToSpawn;


    protected override Status OnStart()
    {
        sList = new List<Sequence>();
        ListCopies.Value = new();
        foreach (var p in ListPositions.Value)
        {
            GameObject v = MonoBehaviour.Instantiate(Copies.Value, p + Vector3.down * distanceToMove, Quaternion.identity);
            Vector3 scale = v.transform.localScale;
            v.transform.localScale = Vector3.zero;

            Sequence s = DOTween.Sequence();
            sList.Add(s);
            s.Append(v.transform.DOScale(scale, timeToSpawn));
            s.Append(v.transform.DOMoveY(p.y, timeToMove).SetEase(easeIn));


            ListCopies.Value.Add(v);
        }
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(sList.All(x => !x.IsPlaying()))
            return Status.Success;
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

