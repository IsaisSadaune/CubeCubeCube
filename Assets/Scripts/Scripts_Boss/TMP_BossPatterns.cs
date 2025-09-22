using UnityEngine;
using DG.Tweening;
public class TMP_BossPatterns : MonoBehaviour
{
    //on va dire qu'elles ont la bonne taille de base
    [SerializeField] private DamageZoneBehaviour prefabDamageZones;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject whisp;
    [SerializeField] private Rigidbody rb;


    [ContextMenu("patternWhisp")]
    public void WhispPattern()
    {
        //partie 0 : choix direction

        //partie 1 : le fouet

        //partie 2 : les explosions
    }
}
