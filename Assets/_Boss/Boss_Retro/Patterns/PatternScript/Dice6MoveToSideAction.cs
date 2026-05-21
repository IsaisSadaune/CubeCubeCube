using DG.Tweening;
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dice6MoveToSide", story: "[Boss] Goes To [PosBoss6] ortogonally", category: "Action", id: "01400196c868e5812306c932a17ab6a4")]
public partial class Dice6MoveToSideAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Boss;
    [SerializeReference] public BlackboardVariable<Transform> PosBoss6;
    private Sequence s;
    protected override Status OnStart()
    {
        s = DOTween.Sequence();

        float tempsX = Mathf.Abs(Mathf.Abs(PosBoss6.Value.transform.position.x) - Mathf.Abs(Boss.Value.transform.position.x)) / 10f;
        float tempsZ = Mathf.Abs(Mathf.Abs(PosBoss6.Value.transform.position.z) - Mathf.Abs(Boss.Value.transform.position.z)) / 10f;
        if (tempsX > tempsZ)
        {
            s.Append(Boss.Value.transform.DOMoveZ(PosBoss6.Value.transform.position.z, tempsZ)).SetEase(Ease.OutQuint);
            s.Append(Boss.Value.transform.DOMoveX(PosBoss6.Value.transform.position.x, tempsX)).SetEase(Ease.OutQuint);
        }
        else
        {
            s.Append(Boss.Value.transform.DOMoveX(PosBoss6.Value.transform.position.x, tempsX)).SetEase(Ease.OutQuint);
            s.Append(Boss.Value.transform.DOMoveZ(PosBoss6.Value.transform.position.z, tempsZ)).SetEase(Ease.OutQuint);
        }
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

