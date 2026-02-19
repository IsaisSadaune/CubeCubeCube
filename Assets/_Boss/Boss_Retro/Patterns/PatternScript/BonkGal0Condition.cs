using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Bonk égal 0", story: "[Bonk] is equal to [Zero]", category: "Conditions", id: "2d6c8ee6ec546870e3fe60907be62400")]
public partial class BonkGal0Condition : Condition
{
    [SerializeReference] public BlackboardVariable<int> Bonk;
    [SerializeReference] public BlackboardVariable<int> Zero;

    public override bool IsTrue()
    {
        if(Bonk.Value <= 10)
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
