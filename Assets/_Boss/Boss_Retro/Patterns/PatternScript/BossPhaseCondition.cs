using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "BossPhase", story: "[Boss_Variables] hps < [phaseHP]", category: "Conditions", id: "190759d0a73d71ae0e716358762b74a7")]
public partial class BossPhaseCondition : Condition
{
    [SerializeReference] public BlackboardVariable<Boss_Variables> Boss_Variables;
    [SerializeReference] public BlackboardVariable<int> PhaseHP;

    public override bool IsTrue()
    {
       if(Boss_Variables.Value.HP <= PhaseHP.Value) return true;

       else return false;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
