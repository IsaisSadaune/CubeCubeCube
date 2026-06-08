using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public Player player;
    public CapsuleCollider capsule;
    public LayerMask obstacleMask;

    [Header("Mesh Related")]
    public float timeActive = 2f;
    public float meshRefreshRate = 0.1f;
    public Transform positionToSpawn;
    public Material mat;
    private SkinnedMeshRenderer[] skinnedMeshRenderers;
    int clip = 0;


    public void StartDash()
    {
        switch (clip)
        {
            case 0:
                AudioManager.Instance.SoundStop("Dash 3");
                AudioManager.Instance.PlaySound("Dash");
                clip++;
                break;
            case 1:
                AudioManager.Instance.SoundStop("Dash");
                AudioManager.Instance.PlaySound("Dash 2");
                clip++;
                break;
            case 2:
                AudioManager.Instance.SoundStop("Dash 2");
                AudioManager.Instance.PlaySound("Dash 3");
                clip = 0;
                break;
        }

        if (!player.isDead)
        {
            StartCoroutine(DashCoroutine());
            StartCoroutine(DashTrail(timeActive));
        }
    }

    #region Coroutines
    public IEnumerator DashCoroutine()
    {
        AudioManager.Instance.PlaySound("Dash");
        Debug.Log("DashCoroutine");
        player.canDash = false;
        player.hitbox.enabled = false;

        float startTime = Time.time;

        Vector3 startPos = player.rb.position;

        Vector3 dashDir = (player.dashDirection != Vector3.zero
                        ? player.dashDirection
                        : player.transform.forward).normalized;

        Vector3 worldCenter = capsule.transform.TransformPoint(capsule.center);
        float halfHeight = capsule.height / 2f - capsule.radius;

        Vector3 p1 = worldCenter + Vector3.up * halfHeight;
        Vector3 p2 = worldCenter - Vector3.up * halfHeight;

        RaycastHit hit;
        float dashDistance = player.dashForce;

        if (Physics.CheckCapsule(p1, p2, capsule.radius, obstacleMask))
        {
            dashDistance = 0f;

            player.stateMachine.ChangeState(player.idleState);
            yield return new WaitForSeconds(player.dashCooldown);
            player.canDash = true;
            yield break;
        }

        else if (Physics.CapsuleCast(p1, p2, capsule.radius, dashDir, out hit, player.dashForce, obstacleMask))
        {
            dashDistance = Mathf.Max(hit.distance - 0.05f, 0f);
        }

        float dashTime = dashDistance / player.dashForce * player.dashDuration;
        Vector3 endPos = startPos + dashDir * dashDistance;


        while (Time.time < startTime + dashTime)
        {
            float t = (Time.time - startTime) / dashTime;
            player.rb.MovePosition(Vector3.Lerp(startPos, endPos, t));
            yield return new WaitForFixedUpdate();
        }

        player.stateMachine.ChangeState(player.idleState);


        yield return new WaitForSeconds(player.dashCooldown);
        player.canDash = true;

    }

    public IEnumerator DashTrail(float time)
    {
        while (time > 0)
        {

            time -= meshRefreshRate;

            if (skinnedMeshRenderers == null || skinnedMeshRenderers.Length == 0)
            {
                skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
                //Debug.Log("SkinnedMeshes found: " + skinnedMeshRenderers.Length);
            }

            for (int i = 0; i < skinnedMeshRenderers.Length; i++)
            {
                GameObject gObj = new GameObject("TrailMesh");
                gObj.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                gObj.transform.rotation = transform.rotation;

                MeshRenderer mr = gObj.AddComponent<MeshRenderer>();
                MeshFilter mf = gObj.AddComponent<MeshFilter>();

                Mesh mesh = new Mesh();
                skinnedMeshRenderers[i].BakeMesh(mesh);
                mf.mesh = mesh;
                mr.material = mat;

                Destroy(gObj, 0.2f);
            }

            yield return new WaitForSeconds(meshRefreshRate);
        }
    }
    #endregion
}
