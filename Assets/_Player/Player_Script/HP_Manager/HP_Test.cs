using System.Collections;
using UnityEngine;

public class HP_Test : MonoBehaviour
{
    [SerializeField] private int hp_max;
    int current_hp;
    [SerializeField] private int mp_max;
    int current_mp;
    public Player player;
    [SerializeField] private UI_Player uip;
    [SerializeField] private GameObject reloadButton;
    public bool isLosingMps;
    public float lastMpGain;
    private Coroutine MpsLoss;

    void Start()
    {
        reloadButton.SetActive(false);
        current_hp = hp_max;
        if (uip != null)
            uip.SetHps(current_hp);
            uip.SetMps(current_mp);
            uip.UpdateMps(current_mp);
    }

    void Update()
    {

        if(Time.time > lastMpGain + 0.5f)
        {
            isLosingMps = true;
        }

        if(isLosingMps && current_mp != mp_max)
        {
            if(MpsLoss == null)
                MpsLoss = StartCoroutine(MpLoss());
                else
                return;
        }
        else
            MpsLoss = null;
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
        Debug.Log(1);
        if(current_mp > 0)
        {
            Debug.Log(2);
            current_mp -= mp;
            uip.UpdateMps(current_mp);
        }
    }
    public void GainMP(int mp)
    {
        isLosingMps = false;
        if(current_mp + mp < mp_max)
        {
            current_mp += mp;
        }
        else
            current_mp = mp_max;

        uip.UpdateMps(current_mp);
        lastMpGain = Time.time;
        
    }
    

    IEnumerator MpLoss()
    {
        while(isLosingMps)
        {
            LoseMP(1);
            yield return new WaitForSeconds(0.2f);
        }
    }
    
#endregion
}