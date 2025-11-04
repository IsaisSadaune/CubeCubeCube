using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "PlayerDeath", story: "[Player] is Dead", category: "Conditions", id: "93b11906aaea9d941fb34511380ee22d")]
public partial class PlayerDeathCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Player;

    public override bool IsTrue()
    {
        return Player.Value == null;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
