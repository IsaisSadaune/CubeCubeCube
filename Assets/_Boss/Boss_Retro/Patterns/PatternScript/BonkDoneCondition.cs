using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "BonkDone", story: "BonkDone is finished", category: "Conditions", id: "97bc55bd5abdf8070e5937bafec76517")]
public partial class BonkDoneCondition : Condition
{

    public override bool IsTrue()
    {
        
        return true;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
