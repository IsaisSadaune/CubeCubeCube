using System.Collections;
using UnityEngine;

public class HP_Test : MonoBehaviour
{
    [SerializeField] private int hp_max;
    int current_hp;
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
        if(player.actualSuper == Super.Heal)
        {
            mp_max = player.healing.mp_Cost;
        }
        if(player.actualSuper == Super.GapClose)
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
        if (upf != null)
            upf.RemoveHP(x);

        if (current_hp <= 0)
        {
            current_hp = 0;
            KillPlayer();
        }
    }

    public void GainHP(int x)
    {
        current_hp += x;
        if(current_hp >= hp_max)
        {
            current_hp = hp_max;
        }
        for(int i = 0; i < x; i++)
        {
            upf.AddHP();
        }
        Debug.Log(current_hp);
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
        if (current_mp > 0)
        {
            current_mp = Mathf.Max(0, current_mp - mp);
            rageBar.DecreaseBarValue(mp);
        }
    }
    public void GainMP(int mp)
    {
        current_mp = Mathf.Min(current_mp + mp, mp_max);
        rageBar.IncreaseRageBar(mp);
    }


    IEnumerator MpLoss()
    {
        while (current_mp < mp_max)
        {
            LoseMP(1);
            yield return new WaitForSeconds(0.75f);
        }
    }

    #endregion
}