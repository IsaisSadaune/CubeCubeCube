using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "PongFinish", story: "[Bonk] is equal to [ten] or more", category: "Conditions", id: "a2d8eb3ab42060cf9571819471d9496f")]
public partial class PongFinishCondition : Condition
{
    [SerializeReference] public BlackboardVariable<int> Bonk;
    [SerializeReference] public BlackboardVariable<int> Ten;

    public override bool IsTrue()
    {
        Bonk.Value = RetroBoss.Instance.bonk;

        if(Bonk.Value >= 10) 
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
