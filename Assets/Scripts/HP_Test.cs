using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class HP_Test : MonoBehaviour
{
    [SerializeField] private int hp_max;
    int current_hp;
    public Player player;
    [SerializeField] private UI_Player uip;

    void Start()
    {
        current_hp = hp_max;
        if(uip != null)
            uip.SetHps(current_hp);
    }

    public void LoseHP(int x)
    {
        current_hp -= x;
        if (uip != null)
            uip.RemoveHP(x);

        if(current_hp <=0)
        {
            current_hp = 0;
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        player.isDead = true;
        //Debug.Log("je suis mort ouch");
        player.deathFeedback.PlayFeedbacks();
        player.animator.SetBool("isDead", true);
    }

}
