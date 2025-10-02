using DG.Tweening;
using System.Collections;
using UnityEngine;
public class TMP_DamageBehaviour : MonoBehaviour
{
    [SerializeField] private Material damagedMaterial;
    private Material originalMaterial;
    private bool isDamaged;
    private Tween F_dmg;
    private Vector3 originalScale;

    private void Awake()
    {
        originalMaterial = transform.GetComponent<Material>();
        originalScale = transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("bossTrigger");
        if (other.CompareTag("CanDamageBoss"))
        {
            if(F_dmg != null)
            {
                F_dmg.Kill();
                transform.localScale = originalScale;
            }
            //perdre de la vie
        }
    }

}
