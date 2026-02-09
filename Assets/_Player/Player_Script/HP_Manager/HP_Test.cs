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
    [SerializeField] private GameObject reloadButton;
    private bool isLosingMps;
    public bool canUlt = false;
    private Coroutine MpsLoss;

    void Start()
    {
        reloadButton.SetActive(false);
        current_hp = hp_max;
        current_mp = 20;
        if (uip != null)
            uip.SetHps(current_hp);
            uip.SetMps(mp_max);
            uip.UpdateMps(current_mp);
    }

    void Update()
    {
        if(current_mp != mp_max)
        {
            canUlt = false;
            isLosingMps = true;
            if(MpsLoss == null)
                MpsLoss = StartCoroutine(MpLoss());
                else
                return;
        }
        else
            MpsLoss = null;
            canUlt = true;
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
        reloadButton.SetActive(true);
    }
#endregion

#region mp
    public void LoseMP(int mp)
    { 
        if(current_mp > 0)
        {
            current_mp -= mp;
            uip.UpdateMps(current_mp);
        }
    }
    public void GainMP(int mp)
    {
        Debug.Log("a");
        isLosingMps = false;

        current_mp += mp;

        uip.UpdateMps(current_mp);    
    }
    

    IEnumerator MpLoss()
    {
        while(isLosingMps)
        {
            LoseMP(1);
            yield return new WaitForSeconds(0.75f);
        }
    }
    
#endregion
}