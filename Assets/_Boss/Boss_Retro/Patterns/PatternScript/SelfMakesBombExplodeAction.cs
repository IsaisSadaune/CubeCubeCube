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

    bool done;
    protected override Status OnStart()
    {
        done = false;
        float distance = Vector3.Distance(Self.Value.transform.position, BombList.Value[0].transform.position);
        float timeToGo = 3.5f / distance;
        Self.Value.transform.DOMove(new Vector3(BombList.Value[0].transform.position.x, 5f, BombList.Value[0].transform.position.z), timeToGo).SetEase(Ease.Linear).OnComplete(() =>
        {
            Self.Value.transform.DOMoveY(2f, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                GameObject bomb = BombList.Value[0];
                BombList.Value.Remove(bomb);
                MonoBehaviour.Destroy(bomb);
                RetroBoss.Instance.Explosion(Explosion);
                done = true;
            });
        });
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(done) return Status.Success;
        else return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

