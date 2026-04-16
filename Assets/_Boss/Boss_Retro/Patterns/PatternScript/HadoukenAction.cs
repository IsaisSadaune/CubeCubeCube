using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;
using Unity.AppUI.Core;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Hadouken", story: "Throw a [Fireball] towards player at [fireballSpeed]", category: "Action", id: "98e68ac68a80169273f9cf4d376690f0")]
public partial class HadoukenAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Fireball;
    [SerializeReference] public BlackboardVariable<float> FireballSpeed;
    protected override Status OnStart()
    {
        GameObject fireball = RetroBoss.Instance.Hadouken(Fireball.Value, FireballSpeed.Value);
        Debug.Log(fireball.transform.position);
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

