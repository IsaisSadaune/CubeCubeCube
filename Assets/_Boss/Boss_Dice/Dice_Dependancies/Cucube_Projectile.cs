using DG.Tweening;
using UnityEngine;

public class Cucube_Projectile : MonoBehaviour
{
    float posStartZ = -45f;
    float posEndZ = 60f;

    private void Start()
    {
        transform.DOMoveZ(posEndZ, 3f)
            .SetEase(Ease.Linear)
            .OnComplete( () => Destroy(this.gameObject) );
    }
}
