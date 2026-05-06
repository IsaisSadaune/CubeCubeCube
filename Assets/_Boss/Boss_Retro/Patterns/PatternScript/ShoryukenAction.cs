using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Shoryuken", story: "[Self] uppercut player", category: "Action", id: "854213360f4014d334540865b456e2cf")]
public partial class ShoryukenAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;

    bool done;
        protected override Status OnStart()
        {
            done = false;

            float currentY = Self.Value.transform.rotation.y;
            Quaternion rota = Quaternion.Euler(0, currentY + 180f, 0);
            
            Vector3 dir = (Player.Instance.transform.position - Self.Value.transform.position).normalized;
            Vector3 targetPos = Player.Instance.transform.position - dir * 2f;
            targetPos.y = 2f;

            
            Self.Value.transform.DOMove(targetPos, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                Self.Value.transform.DORotateQuaternion(rota, 0.5f);
                Self.Value.transform.DOMoveY(5f, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    Self.Value.transform.DOMoveY(2f, 0.3f).SetEase(Ease.InOutQuad);
                    done =true;
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

