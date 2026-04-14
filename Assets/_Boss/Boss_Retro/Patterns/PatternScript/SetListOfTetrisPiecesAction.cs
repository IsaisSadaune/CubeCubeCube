using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetListOfTetrisPieces", story: "Set [TetrisPiecesLeft] with [TetrisPieces]", category: "Action", id: "71077ced380ade38a77976b748328011")]
public partial class SetListOfTetrisPiecesAction : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> TetrisPiecesLeft;
    [SerializeReference] public BlackboardVariable<List<GameObject>> TetrisPieces;

    protected override Status OnStart()
    {
        for (int i = 0; i < TetrisPieces.Value.Count; i++)
        {
            TetrisPiecesLeft.Value.Add(TetrisPieces.Value[i]);
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

