using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public Player player;
    public void StartDash()
    {
        StartCoroutine(DashCoroutine());
    }
    
    #region Coroutines
    public IEnumerator DashCoroutine()
    {
        player.canDash = false;
        RaycastHit hit;
        float startTime = Time.time;
        Vector3 startPos = player.rb.position;
        Vector3 endPos;

        if (Physics.Raycast(transform.position, player.rb.transform.forward, out hit, 5f))
        {
            endPos = hit.point * 0.9f;
        }
        else
        {
            endPos = player.rb.position + player.rb.transform.forward * player.dashForce;
        }



        while (Time.time < startTime + player.dashDuration)
        {

            float t = (Time.time - startTime) / player.dashDuration;
            player.rb.MovePosition(Vector3.Lerp(startPos, endPos, t));
            yield return null;
        }
        player.stateMachine.ChangeState(player.idleState);
        yield return new WaitForSeconds(player.dashCooldown);
        player.canDash = true;

    }
    #endregion
}
