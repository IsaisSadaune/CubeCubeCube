using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;
using System.Collections.Generic;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ThrowBomb", story: "Throw each [BombList] at random [ArenaTiles]", category: "Action", id: "956c992198622f91c0e0d3afcde05849")]
public partial class ThrowBombAction : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> BombList;
    [SerializeReference] public BlackboardVariable<List<GameObject>> ArenaTiles;
    bool done;
    protected override Status OnStart()
    {
        done = false;
        
        foreach(GameObject bomb in BombList.Value)
        {
            int rdmPos = UnityEngine.Random.Range(0, ArenaTiles.Value.Count);
            Vector3 pos  = ArenaTiles.Value[rdmPos].transform.position;
            pos.y = 2f;
            ArenaTiles.Value.Remove(ArenaTiles.Value[rdmPos]);
            bomb.transform.DOMove(pos, 1f)
            .SetDelay(UnityEngine.Random.Range(0.1f,0.5f))
            .SetEase(Ease.InOutQuad).OnComplete(() =>
            {
                done = true;
                bomb.GetComponent<BoxCollider>().isTrigger = false;
                bomb.GetComponent<Rigidbody>().isKinematic=false;
            });

        }
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

