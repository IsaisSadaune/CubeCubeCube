using System.Collections;
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
        if (player.resetCombo != null)
        {
            StopCoroutine(player.resetCombo);
        }


        player.combo[xCombo].attackCollider.enabled = true;
        player.rb.AddForce(transform.forward * 2f, ForceMode.Impulse);
        StartCoroutine(ComboTimer());
    }

    public IEnumerator ComboTimer()
    {
        yield return new WaitForSeconds(0.1f);
        player.stateMachine.ChangeState(player.idleState);
        player.resetCombo = StartCoroutine(player.resetingCombo());
    }
}