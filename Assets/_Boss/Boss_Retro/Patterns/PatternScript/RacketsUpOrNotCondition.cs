using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Rackets Up or not", story: "Either if [rackets] are on the arena or not", category: "Conditions", id: "ecab120808f865281dbc2308dbb6cc93")]
public partial class RacketsUpOrNotCondition : Condition
{
    [SerializeReference] public BlackboardVariable<bool> Rackets;

    public override bool IsTrue()
    {
        return Rackets.Value == true;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
