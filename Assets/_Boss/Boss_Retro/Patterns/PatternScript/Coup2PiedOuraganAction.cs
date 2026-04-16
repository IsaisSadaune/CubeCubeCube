using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Coup2PiedOuragan", story: "[Self] goes to player while rotating", category: "Action", id: "1b4a8b6db64ffbaaf8e5c884af62c4b9")]
public partial class Coup2PiedOuraganAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;

    bool done;
    protected override Status OnStart()
    {
        done = false;

        Vector3 pos = Player.Instance.transform.position;
        pos.y += 2;

        Self.Value.transform.DOMove(pos, 1f).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            done = true;
        });
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        float currentY = Self.Value.transform.rotation.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0, currentY + 50, 0);

        Self.Value.transform.DORotateQuaternion(targetRotation, 0.5f);

        if(done) return Status.Success;
        else return Status.Running;
    }

    protected override void OnEnd()
    {
        Self.Value.transform.DORotateQuaternion(Quaternion.identity, 0.5f);
    }
}

