using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;
using Unity.VisualScripting;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SelfMakesBombExplode", story: "[Self] jump on each [BombList] and make [Explosion]", category: "Action", id: "723efe833ae969178d2491e01dcaf800")]
public partial class SelfMakesBombExplodeAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<List<GameObject>> BombList;
    [SerializeReference] public BlackboardVariable<GameObject> Explosion;
    protected override Status OnStart()
    {
        for(int i = 0; i < BombList.Value.Count; i++)
        {
            Self.Value.transform.DOMove(BombList.Value[i].transform.position, 2f).SetEase(Ease.InOutQuad).OnComplete(() =>
            {
                BombList.Value.Remove(BombList.Value[i]);
                GameObject explosion = RetroBoss.Instance.Explosion(Explosion);
                Debug.Log("FAH");
            });
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

