using System.Collections;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public Player player;
    public CapsuleCollider capsule;
    public LayerMask obstacleMask;
    bool obstacleInTheWay;
    bool besideObstacle;
    Vector3 p1;
    Vector3 p2;
    RaycastHit hit;

    public void StartDash()
    {
        StartCoroutine(DashCoroutine());
    }

    void FixedUpdate()
    {
        p1 = player.rb.position + capsule.center + Vector3.up * (capsule.height / 2f - capsule.radius);
        p2 = player.rb.position + capsule.center - Vector3.up * (capsule.height / 2f - capsule.radius);

        if (Physics.CheckCapsule(p1, p2, capsule.radius, obstacleMask))
        {
            besideObstacle = true;
        }
        else
        {
            besideObstacle = false;
        }
        if (Physics.CapsuleCast(p1, p2, capsule.radius, player.rb.transform.forward, out hit, 5f, obstacleMask))
        {
            obstacleInTheWay = true;
        }
        else
        {
            obstacleInTheWay = false;
        }
    }

    #region Coroutines
    public IEnumerator DashCoroutine()
    {
        player.canDash = false;
        float startTime = Time.time;
        Vector3 startPos = player.rb.position;
        Vector3 endPos;

        p1 = player.rb.position + capsule.center + Vector3.up * (capsule.height / 2f - capsule.radius);
        p2 = player.rb.position + capsule.center - Vector3.up * (capsule.height / 2f - capsule.radius);

        if (besideObstacle)
        {
            endPos = player.rb.position;
        }
        else if (obstacleInTheWay)
        {
            endPos = player.rb.position + player.rb.transform.forward * hit.distance;
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
