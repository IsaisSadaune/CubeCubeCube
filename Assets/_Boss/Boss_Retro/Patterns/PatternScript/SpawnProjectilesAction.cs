using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SpawnProjectiles", story: "[Projectiles] get activated for [X]", category: "Action", id: "45aee7aee74cbcd2b34d16597e692aac")]
public partial class SpawnProjectilesAction : Action
{
    [SerializeReference] public BlackboardVariable<SpawnProjectilesCubes> Projectiles;
    [SerializeReference] public BlackboardVariable<float> X;

    private bool finished;
    protected override Status OnStart()
    {
        finished = false;
        Projectiles.Value.SpawnCubes(X.Value);
        Projectiles.Value.GetComponent<MonoBehaviour>().StartCoroutine(cooldown());
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(finished)
            return Status.Success;
        return Status.Running;
    }


    private IEnumerator cooldown()
    {
        yield return new WaitForSeconds(X.Value);
        finished = true;
    }

    
}

