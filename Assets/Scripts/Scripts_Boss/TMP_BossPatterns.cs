using UnityEngine;
using DG.Tweening;
using System.Collections;

public class TMP_BossPatterns : MonoBehaviour
{
    //on va dire qu'elles ont la bonne taille de base
    [SerializeField] private DamageZoneBehaviour prefabDamageZones;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private GameObject prefabWhisp;
    [SerializeField] private Rigidbody rb;
    private Tween WhispTween;



    [ContextMenu("patternWhisp")]
    public void WhispPattern()
    {
        GameObject _whisp = Instantiate(prefabWhisp, transform.position, Quaternion.identity);
    }


    [ContextMenu("damageZones")]
    public void DamagesZones()
    {
        RaycastHit hit;
        for(int i=1;i<5;i++)
        {
            if (Physics.Raycast(transform.position + Vector3.right * 4 * i, Vector3.down, out hit))
            {
                StartCoroutine(DelaySpawn(0.5f * i, hit.point));
            }
            if (Physics.Raycast(transform.position + Vector3.left * 5 * i, Vector3.down, out hit))
            {
                StartCoroutine(DelaySpawn(0.5f * i, hit.point));
            }
            if (Physics.Raycast(transform.position + Vector3.forward * 5 * i, Vector3.down, out hit))
            {
                StartCoroutine(DelaySpawn(0.5f * i, hit.point));
            }
            if (Physics.Raycast(transform.position + Vector3.back * 5 * i, Vector3.down, out hit))
            {
                StartCoroutine(DelaySpawn(0.5f * i, hit.point));
            }
        }
    }


    private IEnumerator DelaySpawn(float f, Vector3 spawnPos)
    {
        yield return new WaitForSeconds(f);
        Instantiate(prefabDamageZones, spawnPos, Quaternion.identity);
    }
}
