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
        if (Player == null || Player.Value == null)
        {
            Debug.Log("Player n'est pas détecté");
            return true;
        }

        Player playerComponent = Player.Value.GetComponent<Player>();

        if (playerComponent == null)
        {
            Debug.LogWarning("Composant Player introuvable sur le GameObject");
            return true;
        }

        Debug.Log(playerComponent);

        if (playerComponent.hps == null)
        {
            Debug.LogWarning("hps non initialisé");
            return false;
        }

        if (playerComponent.hps.current_hp <= 0)
        {
            Debug.Log("Player a 0 HPs");
            return true;
        }

        return false;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
