using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Player player;
    
    void Start()
    {
        player = GetComponent<Player>();
    }
     
    public void LaunchAttack(int xCombo)
    {
        AudioSource slashSound = player.combo[xCombo].attackCollider.gameObject.GetComponent<AudioSource>();
        
        if (player.resetCombo != null)
        {
            StopCoroutine(player.resetCombo);
        }

        player.combo[xCombo].attackCollider.enabled = true;
        //if(slashSound != null)
            //slashSound.Play();
        player.combo[xCombo].attackCollider.gameObject.transform.GetChild(0).gameObject.SetActive(true);

        if(xCombo == 0)
            player.rb.AddForce(transform.forward * 5, ForceMode.VelocityChange);  
    
        StartCoroutine(ComboTimer());
    }

    public IEnumerator ComboTimer()
    {
        
        yield return new WaitForSeconds(0.05f);
        player.bossHit = false;
        player.stateMachine.ChangeState(player.idleState);
        // if(player.bossHit)
        // {
        //     player.bossHit = false;
        //     player.stateMachine.ChangeState(player.idleState);
        // }
        // else
        // {
        //     player.combo[player.comboCount].attackCollider.enabled = false;
        //     yield return new WaitForSeconds(0.25f);
        //     player.stateMachine.ChangeState(player.idleState);
        // }
    }
}