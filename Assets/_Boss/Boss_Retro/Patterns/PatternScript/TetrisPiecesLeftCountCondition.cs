using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "TetrisPiecesLeftCount", story: "[TetrisPiecesLeft] Count > 0", category: "Conditions", id: "b2b53ba65350e88a06746d5cfdba170f")]
public partial class TetrisPiecesLeftCountCondition : Condition
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> TetrisPiecesLeft;

    public override bool IsTrue()
    {
        if(TetrisPiecesLeft.Value.Count > 0)
            return true;
        else
            return false;
    }

    public override void OnStart()
    {
        
    }

    public override void OnEnd()
    {
    }
}
