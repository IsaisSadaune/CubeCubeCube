using System.Collections;
using UnityEngine;

public class HP_Test : MonoBehaviour
{
    [SerializeField] private int hp_max;
    int current_hp;
    [SerializeField] private int mp_max;
    public int current_mp {get; set;}
    public Player player;
    [SerializeField] private UIPlayerFight uip;
    [SerializeField] private UIRageBar uir;
    public bool CanUlt => current_mp >= mp_max;
    private Coroutine MpsLoss;

    void Start()
    {
        uir.rageMax = mp_max;
        current_hp = hp_max;
        current_mp = 0;
        uir.value = current_mp;
        if (uip != null)
        {
            uip.SetMaxHps(current_hp);
            uir.ChangeBarValue(0);
            uir.ChangeBarValue(current_mp);
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
        //GainMP(3);
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
        if (current_mp - mp <= 0)
            current_mp = 0;
        else
            current_mp -= mp;

        uir.DecreaseBarValue(mp);
    }
    public void GainMP(int mp)
    {
        if (current_mp + mp >= mp_max)
            current_mp = mp_max;
        else 
            current_mp += mp;

        uir.IncreaseRageBar(mp);
    }


    IEnumerator MpLoss()
    {
        while (uir.value < mp_max)
        {
            LoseMP(1);
            yield return new WaitForSeconds(0.75f);
        }
    }

    #endregion
}