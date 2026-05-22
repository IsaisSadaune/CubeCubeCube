using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Create Path s visual", story: "Create the [pacmanVisual] at [Path] positions", category: "Action", id: "1801e5682a286c4ef3b733ad22543cb9")]
public partial class CreatePathSVisualAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> PacmanVisual;
    [SerializeReference] public BlackboardVariable<List<Vector3>> Path;
    List<GameObject> gummies = new List<GameObject>();
    protected override Status OnStart()
    {
        foreach(Vector3 pos in Path.Value)
        {
            Debug.Log(pos);
            gummies.Add(MonoBehaviour.Instantiate(PacmanVisual.Value, new Vector3(pos.x, pos.y -1, pos.z), Quaternion.identity));
        }
        RetroBoss.Instance.PacmanGummiesActivation(gummies);
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

