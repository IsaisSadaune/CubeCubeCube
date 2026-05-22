using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Create Path s visual", story: "Create the [pacmanVisual] at [Path] positions", category: "Action", id: "1801e5682a286c4ef3b733ad22543cb9")]
public partial class CreatePathSVisualAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> PacmanVisual;
    [SerializeReference] public BlackboardVariable<List<Vector3>> Path;
    protected override Status OnStart()
    {
        foreach(Vector3 pos in Path.Value)
        {
            MonoBehaviour.Instantiate(PacmanVisual.Value, pos, Quaternion.identity);
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

