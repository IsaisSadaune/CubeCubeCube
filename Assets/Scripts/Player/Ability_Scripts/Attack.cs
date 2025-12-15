using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Player player;
    Coroutine comboCoroutine;
    
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
        if(slashSound != null)
            slashSound.Play();
        player.combo[xCombo].attackCollider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        player.rb.AddForce(transform.forward * 2f, ForceMode.Impulse);

        if(comboCoroutine != null)
        {
           
        }
        comboCoroutine = StartCoroutine(ComboTimer());    
    }

    public IEnumerator ComboTimer()
    {
        yield return new WaitForSeconds(0.05f);
        if(player.bossHit)
        {
            yield return new WaitForSeconds(0.01f);
            player.bossHit = false;
            player.stateMachine.ChangeState(player.idleState);
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            player.stateMachine.ChangeState(player.idleState);
            player.resetCombo = StartCoroutine(player.resetingCombo());
        }
    }
}