using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DiceMultiply", story: "[Copies] of Dice go at [positionsParent]", category: "Action", id: "80bfbf66ff1015be2294bd5987f7c229")]
public partial class DiceMultiplyAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Copies;
    [SerializeReference] public BlackboardVariable<GameObject> PositionsParent;
    protected override Status OnStart()
    {
        foreach(Transform v in PositionsParent.Value.GetComponentInChildren<Transform>())
        {
            var x = MonoBehaviour.Instantiate(Copies.Value, v.position, Quaternion.identity);
            x.GetComponent<CubeCopyTombe>().Falling(-5, 1f);
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

