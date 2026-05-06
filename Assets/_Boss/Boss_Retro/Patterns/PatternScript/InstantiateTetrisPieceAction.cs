using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "InstantiateTetrisPiece", story: "Instantiate one of [TetrisPiecesLeft] at [ArenaTiles] position", category: "Action", id: "16cf250540c1b5d4fe42d50fa87d7050")]
public partial class InstantiateTetrisPieceAction : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> ArenaTiles;
    [SerializeReference] public BlackboardVariable<List<GameObject>> TetrisPiecesLeft;
    bool done = false;
    protected override Status OnStart()
    {
        int rdmPiece = UnityEngine.Random.Range(0, TetrisPiecesLeft.Value.Count);
        //int rdmPos = UnityEngine.Random.Range(0, ArenaTiles.Value.Count);

        GameObject piece = RetroBoss.Instance.tetrisPiece(TetrisPiecesLeft.Value[rdmPiece], Player.Instance.transform.position);
        TetrisPiecesLeft.Value.Remove(piece);

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

