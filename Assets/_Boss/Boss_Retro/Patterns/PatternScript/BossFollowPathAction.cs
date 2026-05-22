using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;
using System.Linq;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "BossFollowPath", story: "[Self] follow the [path] in [X] seconds", category: "Action", id: "59c46d15206e357cc9d6b483c225aa12")]
public partial class BossFollowPathAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<List<Vector3>> Path;
    [SerializeReference] public BlackboardVariable<float> X;
    bool done = false;
    Sequence s;
    protected override Status OnStart()
    {
        float speed = Vector3.Distance(Self.Value.transform.position, Path.Value.Last()) / X.Value;
        done = false;
        s = DOTween.Sequence();
        foreach(var v in Path.Value)
        {
            s.Append(Self.Value.transform.DOMove(new Vector3(v.x, Self.Value.transform.position.y, v.z), speed));
        }
        s.OnComplete(()=> done = true);
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

