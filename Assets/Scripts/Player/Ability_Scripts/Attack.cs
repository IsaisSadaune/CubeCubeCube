using System.Collections;
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
        
        if (player.resetCombo != null)
        {
            StopCoroutine(player.resetCombo);
        }

        
        player.combo[xCombo].attackCollider.enabled = true;
        player.combo[xCombo].attackCollider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        player.rb.AddForce(transform.forward * 2f, ForceMode.Impulse);

        if(comboCoroutine != null)
        {

        }
        comboCoroutine = StartCoroutine(ComboTimer());
    }

    public IEnumerator ComboTimer()
    {
        yield return new WaitForSeconds(0.5f);
        player.stateMachine.ChangeState(player.idleState);
        player.resetCombo = StartCoroutine(player.resetingCombo());
    }
}