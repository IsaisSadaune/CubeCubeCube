using System;
using System.Collections;
using UnityEngine;

public class HP_Test : MonoBehaviour
{
    public event Action RageBarFull;

    [SerializeField] private int hp_max;
    public int current_hp { get; private set; }
    int mp_max = 0;
    public int current_mp { get; set; }
    Player player;
    [SerializeField] private UIPlayerFight upf;
    [SerializeField] public UIRageBar rageBar;
    public bool CanUlt => current_mp >= mp_max;
    private Coroutine MpsLoss;

    void Start()
    {
        player = GetComponent<Player>();
        if (player.actualSuper == Super.Heal)
        {
            mp_max = player.healing.mp_Cost;
        }
        if (player.actualSuper == Super.GapClose)
        {
            mp_max = player.gapClose.mp_Cost;
        }

        player = GetComponent<Player>();
        current_hp = hp_max;
        current_mp = 0;

        if (upf != null)
        {
            upf.SetMaxHps(hp_max);
        }
        if (rageBar != null)
        {
            rageBar.SetRageMax(mp_max);
        }



        MpsLoss = StartCoroutine(MpLoss());

    }

    #region hp
    public void LoseHP(int x)
    {
        if (!player.isDead)
        {
            current_hp -= x;
            player.dmgFeedback.PlayFeedbacks();
            GainMP(3);
            if (upf != null)
                upf.RemoveHP(x);

            if (current_hp <= 0)
            {
                current_hp = 0;
                KillPlayer();
            }
        }
    }

    public void GainHP(int x)
    {
        current_hp += x;
        if (current_hp >= hp_max)
        {
            current_hp = hp_max;
        }
        for (int i = 0; i < x; i++)
        {
            upf.AddHP();
        }
        Debug.Log(current_hp);
    }

    private void KillPlayer()
    {
        if (!player.isDead)
        {
            player.isDead = true;
            player.deathFeedback.PlayFeedbacks();
            player.animator.SetBool("isDead", true);
        }
    }
    #endregion

    #region mp
    public void LoseMP(int mp)
    {
        if (current_mp > 0)
        {
            current_mp = Mathf.Max(0, current_mp - mp);
            rageBar.DecreaseBarValue(mp);
        }
    }
    public void GainMP(int mp)
    {
        ResetMpTimer();
        current_mp = Mathf.Min(current_mp + mp, mp_max);

        if (current_mp >= mp_max)
            RageBarFull?.Invoke();

        rageBar.IncreaseRageBar(mp);

    }


    IEnumerator MpLoss()
    {
        yield return new WaitForSeconds(0.75f);
        if (current_mp < mp_max)
        {
            LoseMP(1);
        }
        MpsLoss = StartCoroutine(MpLoss());
    }

    public void ResetMpTimer()
    {
        StopCoroutine(MpsLoss);
        MpsLoss = StartCoroutine(MpLoss());
    }


    #endregion
}