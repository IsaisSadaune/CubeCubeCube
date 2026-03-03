using System.Collections;
using UnityEngine;

public class HP_Test : MonoBehaviour
{
    [SerializeField] private int hp_max;
    int current_hp;
    [SerializeField] private int mp_max;
    public int current_mp {get; set;}
    public Player player;
    [SerializeField] private UI_Player uip;

    public bool CanUlt => current_mp >= mp_max;
    private Coroutine MpsLoss;

    void Start()
    {
        current_hp = hp_max;
        current_mp = 0;
        if (uip != null)
        {
            uip.SetHps(current_hp);
            uip.SetMps(mp_max);
            uip.UpdateMps(current_mp);
        }
    }

        void Update()
    {
        if (current_mp < mp_max)
        {
            if (MpsLoss == null)
                MpsLoss = StartCoroutine(MpLoss());
        }
        else
        {
            if (MpsLoss != null)
            {
                StopCoroutine(MpsLoss);
                MpsLoss = null;
            }
        }
    }
#region hp
    public void LoseHP(int x)
    {
        current_hp -= x;
        GainMP(3);
        if (uip != null)
            uip.RemoveHP(x);

        if (current_hp <= 0)
        {
            current_hp = 0;
            KillPlayer();
        }
    }
    private void KillPlayer()
    {
        player.isDead = true;
        player.deathFeedback.PlayFeedbacks();
        player.animator.SetBool("isDead", true);
    }
#endregion

#region mp
    public void LoseMP(int mp)
    { 
        if(current_mp > 0)
        {
            current_mp = Mathf.Max(0, current_mp - mp);
            uip.UpdateMps(current_mp);
        }
    }
    public void GainMP(int mp)
    {
        current_mp = Mathf.Min(current_mp + mp, mp_max);
        uip.UpdateMps(current_mp);
    }
    

    IEnumerator MpLoss()
    {
        while(current_mp < mp_max)
        {
            LoseMP(1);
            yield return new WaitForSeconds(0.75f);
        }
    }
    
#endregion
}