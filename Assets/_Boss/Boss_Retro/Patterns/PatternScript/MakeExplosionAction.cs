using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MakeExplosion", story: "Instantiate [Explosion] at position", category: "Action", id: "e8b6ad82e614bc281133ca72aec64b5f")]
public partial class MakeExplosionAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Explosion;

    protected override Status OnStart()
    {
        RetroBoss.Instance.Explosion(Explosion);
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

