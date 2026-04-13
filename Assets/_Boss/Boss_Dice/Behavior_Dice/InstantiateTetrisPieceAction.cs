using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "InstantiateTetrisPiece", story: "Instantiate one of [TetrisPieces] at [ArenaTiles] position", category: "Action", id: "16cf250540c1b5d4fe42d50fa87d7050")]
public partial class InstantiateTetrisPieceAction : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> TetrisPieces;
    [SerializeReference] public BlackboardVariable<List<GameObject>> ArenaTiles;

bool done = false;
    protected override Status OnStart()
    {
        int rdmPiece = UnityEngine.Random.Range(0, TetrisPieces.Value.Count);
        int rdmPos = UnityEngine.Random.Range(0, ArenaTiles.Value.Count);

        GameObject piece = RetroBoss.Instance.tetrisPiece(TetrisPieces.Value[rdmPiece], ArenaTiles.Value[rdmPos].transform.position);
        TetrisPieces.Value.Remove(piece);
        ArenaTiles.Value.Remove(ArenaTiles.Value[rdmPos]);

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

