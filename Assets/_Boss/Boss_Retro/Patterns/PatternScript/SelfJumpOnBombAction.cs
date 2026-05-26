using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;
using Unity.VisualScripting;
using MoreMountains.Feedbacks;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SelfJumpOnBomb", story: "[Self] jump on each [BombList] at [SpeedBomb] and play [BombFeedbacks]", category: "Action", id: "723efe833ae969178d2491e01dcaf800")]
public partial class SelfJumpOnBombAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<List<GameObject>> BombList;
    [SerializeReference] public BlackboardVariable<float> SpeedBomb;
    [SerializeReference] public BlackboardVariable<MMF_Player> BombFeedbacks;
    bool done;
    protected override Status OnStart()
    {
        done = false;
        BombList.Value[0].GetComponent<MeshRenderer>().material.color = Color.red;
        float distance = Vector3.Distance(Self.Value.transform.position, BombList.Value[0].transform.position);
        float timeToGo = distance / SpeedBomb.Value;
        Self.Value.transform.DOMove(new Vector3(BombList.Value[0].transform.position.x, 5f, BombList.Value[0].transform.position.z), timeToGo).SetEase(Ease.Linear).OnComplete(() =>
        {
            Self.Value.transform.DOMoveY(2f, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                GameObject bomb = BombList.Value[0];
                BombList.Value.Remove(bomb);
                MonoBehaviour.Destroy(bomb);
                // BombFeedbacks.Value.PlayFeedbacks();
                AudioManager.Instance.PlaySound("Explosion");
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

