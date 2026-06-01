using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DestroyClones", story: "Destroy Boss Clones", category: "Action", id: "e3da15015f12b809b4bb65cb0b3f00ef")]
public partial class DestroyClonesAction : Action
{

    protected override Status OnStart()
    {
        foreach(GameObject go in RetroBoss.Instance.clones)
        {
            MonoBehaviour.Destroy(go);
        }
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

