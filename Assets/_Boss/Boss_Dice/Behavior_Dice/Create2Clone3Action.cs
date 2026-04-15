using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Create2Clone_3", story: "Create Two [Clones] and save them [here1] and [here2]", category: "Action", id: "8267c46c8de40159bf2c41c4d598f6ee")]
public partial class Create2Clone3Action : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Clones;
    [SerializeReference] public BlackboardVariable<Transform> Here1;
    [SerializeReference] public BlackboardVariable<Transform> Here2;
    protected override Status OnStart()
    {
        GameObject clone1 = (GameObject)MonoBehaviour.Instantiate(Clones);
        GameObject clone2 = (GameObject)MonoBehaviour.Instantiate(Clones);
        Here1.Value = clone1.transform;
        Here2.Value = clone2.transform;
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

