using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class TMP_BossPatterns : MonoBehaviour
{
    //on va dire qu'elles ont la bonne taille de base
    [Header("Whisp")]
    [SerializeField] private DamageZoneBehaviour prefabDamageZones;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private GameObject prefabWhisp;
    [SerializeField] private Rigidbody rb;
    [Header("Explosions")]
    [SerializeField] private GameObject prefabExplo;
    [SerializeField] private int numberOfExplosions;
    [SerializeField] private Transform MaxPos;
    [SerializeField] private Transform MinPos;
    [SerializeField] private int distanceMiniFromBoss;


    [ContextMenu("Explosions")]
    public void Explo()
    {
        for(int i=0; i<numberOfExplosions; i++) 
        {
            Vector3 _position = transform.position;
            do
            {
                _position = new Vector3(Random.Range(MinPos.position.x, MaxPos.position.x),-2, Random.Range(MinPos.position.z, MaxPos.position.z));
            }
            while (Vector3.Distance(_position, transform.position) < distanceMiniFromBoss + 3);
            Instantiate(prefabExplo, _position, Quaternion.identity);
        }
    }

    [ContextMenu("patternWhisp")]
    public void WhispPattern()
    {
        GameObject _whisp = Instantiate(prefabWhisp, transform.position, Quaternion.identity);
        _whisp.GetComponent<WhispBehaviour>().F_SpawnObject();

    }

    [ContextMenu("Pattern")]
    public void CoroutinePattern() => StartCoroutine(Pattern());

    private IEnumerator Pattern()
    {
        WhispPattern();
        yield return new WaitForSeconds(1f);
        DamagesZones();
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
