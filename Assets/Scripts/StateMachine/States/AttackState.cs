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
        Debug.Log("J'entre dans l'état : " + stateMachine.currentPlayerState);
        
        player.attack.LaunchAttack(player.comboCount);
        
        
    }
    public override void ExitState()
    {
        player.combo[player.comboCount].attackCollider.enabled = false;
        player.animator.SetBool(player.combo[player.comboCount].animName, false);

        if (player.comboCount < 2)
        {
            player.comboCount++;
            Debug.Log("a");
        }
        else
        {
            player.lastComboEnd = Time.time;
            player.comboCount = 0;
        }
    }
    public override void FrameUpdate()
    {

    }

    public override void PhysicsUpdate()
    {

    }

}
