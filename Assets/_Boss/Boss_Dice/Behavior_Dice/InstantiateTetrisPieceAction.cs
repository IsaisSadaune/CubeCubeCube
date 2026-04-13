using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "InstantiateTetrisPiece", story: "[Self] jump and Instantiate one of [TetrisPieces] at [ArenaTiles] position", category: "Action", id: "a132c4f6e9c8520e5f07ea41cb9bd261")]
public partial class InstantiateTetrisPieceAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<List<GameObject>> TetrisPieces;
    [SerializeReference] public BlackboardVariable<List<GameObject>> ArenaTiles;

    private bool done = false;
    List<GameObject> TetrisPiecesLeft;
    protected override Status OnStart()
    {
        for (int i = 0; i < TetrisPieces.Value.Count; i++)
        {
            TetrisPiecesLeft.Add(TetrisPieces.Value[i]);
        }

        while (TetrisPiecesLeft.Count > 0)
        {
            Self.Value.transform.DORotate(new Vector3(0, 180, 0), 0.5f, RotateMode.Fast);
            Self.Value.transform.DOMoveY(6f, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                Self.Value.transform.DOMoveY(2f, 0.1f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    int rdm = UnityEngine.Random.Range(0, TetrisPiecesLeft.Count);
                    int rdmPos = UnityEngine.Random.Range(0, ArenaTiles.Value.Count);

                    RetroBoss.Instance.tetrisPiece(TetrisPiecesLeft[rdm], new Vector3(ArenaTiles.Value[rdmPos].transform.position.x,
                        ArenaTiles.Value[rdmPos].transform.position.y + 10,
                        ArenaTiles.Value[rdmPos].transform.position.z));

                    TetrisPiecesLeft.Remove(TetrisPiecesLeft[rdm]);
                });
            });
        }
        done = true;
        
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
       if(done) return Status.Success;

       else return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

