using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FireballPrevi", story: "[Visual] blink", category: "Action", id: "55f0b9fc7938e9d228e85958fe2d3959")]
public partial class FireballPreviAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Visual;

    protected override Status OnStart()
    {
        Color originalColor = Visual.Value.GetComponent<MeshRenderer>().material.color;

        Visual.Value.transform.DOShakePosition(0.1f).OnComplete(() =>
        {
            Visual.Value.GetComponent<MeshRenderer>().material.color = Color.blue;
        }).OnComplete(() =>
        {
             Visual.Value.transform.DOShakePosition(0.1f).OnComplete(() =>
                {
                    Visual.Value.GetComponent<MeshRenderer>().material.color = originalColor;
                });
        });
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

