using NUnit.Framework.Internal.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float timeBeforeEndCombo;
    Player player;
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
        player.animator.SetBool(player.combo[xCombo].animName, true);
        player.rb.AddForce(transform.forward * 2f, ForceMode.Impulse);
        StartCoroutine(ComboTimer());
    }

    public IEnumerator ComboTimer()
    {
        yield return new WaitForSeconds(0.2f);
        player.lastAttack = Time.time; 
        player.stateMachine.ChangeState(player.idleState);
        player.resetCombo = StartCoroutine(player.resetingCombo());
    }
}