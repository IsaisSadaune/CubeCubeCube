using System.Threading.Tasks;
using UnityEngine;

public class AttackState : PlayerState
{
    public AttackState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {

    }

    int combo;

    public override async void EnterState()
    {
        Debug.Log("J'entre dans l'état : " + stateMachine.currentPlayerState);
        await Attack();
    }
    public override void ExitState()
    {

    }
    public override void FrameUpdate()
    {


    }

    public override void PhysicsUpdate()
    {

    }

    async Task Attack()
    {
        // switch (combo)
        // {
        //     case 0:
        //         player.attacksCollider[0].gameObject.SetActive(true);
        //         await Task.Delay(500);
        //         player.attacksCollider[0].gameObject.SetActive(false);
        //         combo++;
        //         break;
        //     case 1:
        //         player.attacksCollider[1].gameObject.SetActive(true);
        //         await Task.Delay(500);
        //         player.attacksCollider[1].gameObject.SetActive(false);
        //         combo++;
        //         break;
        //     case 2:
        //         player.attacksCollider[2].gameObject.SetActive(true);
        //         await Task.Delay(500);
        //         player.attacksCollider[2].gameObject.SetActive(false);
        //         await Task.Delay(1000);
        //         combo = 0;
        //         break;
        //     default:
        //         break;
        // }
        
    }
}
