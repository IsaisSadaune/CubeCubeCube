using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AttackState : PlayerState
{
    public AttackState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {

    }
    
    public override void EnterState()
    {
        //Debug.Log("J'entre dans l'état : " + stateMachine.currentPlayerState);
        //Debug.Log(player.comboCount);
        player.attack.LaunchAttack(player.comboCount);
        player.animator.SetBool(player.attacksAnimation[player.comboCount], true);
        player.lastAttack = Time.time;

        player.speed /= 2;
    }
    public override void ExitState()
    {
        player.combo[player.comboCount].attackCollider.enabled = false;
        player.combo[player.comboCount].attackCollider.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        player.animator.SetBool(player.attacksAnimation[player.comboCount], false);

        if (player.comboCount < 2)
        {
            player.comboCount++;
            player.lastAttack = Time.time;
        }
        else
        {
            player.lastComboEnd = Time.time;
            player.comboCount = 0;
        }
        player.speed *= 2;
    }
    public override void FrameUpdate()
    {
        
    }

    public override void PhysicsUpdate()
    {

    }

}
