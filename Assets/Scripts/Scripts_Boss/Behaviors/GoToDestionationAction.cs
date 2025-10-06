using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GoToDestionation", story: "[Self] goes to [Destination] squarely", category: "Action", id: "129a8c0a2445684181aa0d3c17da46c7")]
public partial class GoToDestionationAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Transform> Destination;
    private Vector3 destinationX;
    private Vector3 destinationZ;
    private bool XpositionLanded;


    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (!XpositionLanded)
        {
            Self.Value.transform.Translate(Vector3.right * Destination.Value.transform.position.x * Time.deltaTime * 5f); //peut-etre que c'est une mauvaise idée on sait pas
            if (Mathf.Abs(Self.Value.transform.position.x - Destination.Value.transform.position.x) < 0.5f)
            {
                XpositionLanded = true;
            }
        }
        else
        {
            if (Mathf.Abs(Self.Value.transform.position.z - Destination.Value.transform.position.z) < 0.5f)
            {
                return Status.Success;
            }
            Self.Value.transform.Translate(Vector3.forward * Destination.Value.transform.position.z * Time.deltaTime * 5f); //peut-etre que c'est une mauvaise idée on sait pas
        }
        return Status.Running;
    }

}

