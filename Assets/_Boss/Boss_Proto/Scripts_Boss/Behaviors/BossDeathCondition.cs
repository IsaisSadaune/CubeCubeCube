using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "BossDeath", story: "[Boss] is dead", category: "Conditions", id: "bb053a98da74ad3bb1efc20c5368d7aa")]
public partial class BossDeathCondition : Condition
{
    [SerializeReference] public BlackboardVariable<Boss_Variables> Boss;

    public override bool IsTrue()
    {
        //Debug.Log("Boss Mort ? : "+Boss.Value.HP );
        return Boss.Value.HP <= 0;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
