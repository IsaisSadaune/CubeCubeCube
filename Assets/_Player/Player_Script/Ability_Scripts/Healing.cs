using UnityEngine;

public class Healing : MonoBehaviour
{
    Player player;
    public int healPower;
    public int mp_Cost;

    void Start()
    {
        player = GetComponent<Player>();
    }
    public void Heal()
    {
        player.hps.GainHP(healPower);       
        player.stateMachine.ChangeState(player.idleState);
        player.hps.current_mp = 0;
            player.hps.rageBar.DecreaseBarValue(mp_Cost);
    }
}