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

    [SerializeField]
    private SkinnedMeshRenderer[] skinnedMeshRenderers;
    [SerializeField]
    private bool isTrailActive = false;
    
    public void StartDash()
    {
        StartCoroutine(DashCoroutine());
        if(!isTrailActive)
        {
            isTrailActive = true;
            StartCoroutine(DashTrail(timeActive));
        }
    }



    #region Coroutines
    public IEnumerator DashCoroutine()
    {
        player.canDash = false;
        RaycastHit hit;
        float startTime = Time.time;
        Vector3 startPos = player.rb.position;
        Vector3 endPos;

        Vector3 p1 = player.rb.position + capsule.center + Vector3.up * (capsule.height / 2f - capsule.radius);
        Vector3 p2 = player.rb.position + capsule.center - Vector3.up * (capsule.height / 2f - capsule.radius);

        if (Physics.CheckCapsule(p1, p2, capsule.radius, obstacleMask))
        {
            endPos = player.rb.position;
        }
        else if (Physics.CapsuleCast(p1, p2, capsule.radius, player.rb.transform.forward, out hit, 5f, obstacleMask))
        {
            if (player.dashDirection != Vector3.zero)
                endPos = player.rb.position + player.dashDirection * hit.distance;
            else
                endPos = player.rb.position + player.transform.forward * hit.distance;
        }
        else
        {
            if (player.dashDirection != Vector3.zero)
                endPos = player.rb.position + player.dashDirection * player.dashForce;
            else
                endPos = player.rb.position + player.transform.forward * player.dashForce;
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
   
   public IEnumerator DashTrail(float time)
    {
        while (time > 0)
        {

            time -= meshRefreshRate;

            if (skinnedMeshRenderers == null || skinnedMeshRenderers.Length == 0)
{
    skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
    Debug.Log("SkinnedMeshes found: " + skinnedMeshRenderers.Length);
}

for (int i = 0; i < skinnedMeshRenderers.Length; i++)
{
    GameObject gObj = new GameObject("TrailMesh");
    gObj.transform.position = positionToSpawn.position;
    gObj.transform.rotation = skinnedMeshRenderers[i].transform.rotation;

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
        isTrailActive = false;
    }
    #endregion
}
